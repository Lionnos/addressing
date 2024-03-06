using LogicLayer.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace LogicLayer.Analyze
{
    public class Classification
    {
        private string ip = "";
        private string classType = "";
        private Address? address;
        private Network? network;

        public Classification(string ip)
        {
            this.ip = ip;
            ipClassification();
        }


        private void ipClassification()
        {
            Transformation transformation = new();
            address = new();
            address = transformation.ipObtain(ip);

            switch (address.w)
            {
                case int w when w == 0:
                    classType = "I"; break;

                case int w when w > 0 && w < 127:
                    classType = "A"; break;

                case int w when w == 127:
                    classType = "L"; break;

                case int w when w >= 128 && w <= 191:
                    classType = "B"; break;

                case int w when w >= 192 && w <= 223:
                    classType = "C"; break;

                case int w when w >= 224 && w <= 239:
                    classType = "D"; break;

                case int w when w >= 240 && w <= 255:
                    classType = "E"; break;
            }

            asigned(classType);
        }


        private void asigned(string classType)
        {
            switch (classType)
            {
                case "A":
                    network = new() {
                        ipClass = classType,
                        networkMask = new Address() { w = 255, x = 0, y = 0, z = 0 },
                        networkId = new Address() { w = address?.w },
                        hostId = new Address() { x = address?.x, y = address?.y, z = address?.z},
                        networkIp = new Address() { w = address?.w, x = 0, y = 0, z = 0 },
                        hostIp = new Address() { w = address?.w, x = address?.x, y = address?.y, z = address?.z },
                        bitsNetworkId = new AddressBits() { },
                        bitsHostId = new AddressBits() { },

                        broadcast = new Address() { w = address?.w, x = 255, y = 255, z = 255 },
                        numberNetworks = (int) Math.Pow(2, 24),
                        numberUsableNetworks = (int)Math.Pow(2, 24) - 2,
                    }; break;

                case "B":
                    network = new()
                    {
                        ipClass = classType,
                        networkMask = new Address() { w = 255, x = 255, y = 0, z = 0 },
                        networkId = new Address() { w = address?.w, x = address?.x },
                        hostId = new Address() { y = address?.y, z = address?.z },
                        networkIp = new Address() { w = address?.w, x = address?.x, y = 0, z = 0 },
                        hostIp = new Address() { w = address?.w, x = address?.x, y = address?.y, z = address?.z },
                        bitsNetworkId = new AddressBits() { },
                        bitsHostId = new AddressBits() { },

                        broadcast = new Address() { w = address?.w, x = address?.x, y = 255, z = 255 },
                        numberNetworks = (int)Math.Pow(2, 16),
                        numberUsableNetworks = (int)Math.Pow(2, 16) - 2,
                    }; break;

                case "C":
                    network = new()
                    {
                        ipClass = classType,
                        networkMask = new Address() { w = 255, x = 255, y = 255, z = 0 },
                        networkId = new Address() { w = address?.w, x = address?.x, y = address?.y },
                        hostId = new Address() { z = address?.z },
                        networkIp = new Address() { w = address?.w, x = address?.x, y = address?.y, z = 0 },
                        hostIp = new Address() { w = address?.w, x = address?.x, y = address?.y, z = address?.z },
                        bitsNetworkId = new AddressBits() { },
                        bitsHostId = new AddressBits() { },

                        broadcast = new Address() { w = address?.w, x = address?.x, y = address?.y, z = 255 },
                        numberNetworks = (int)Math.Pow(2, 8),
                        numberUsableNetworks = (int)Math.Pow(2, 8) - 2,
                    }; break;

                case "D":
                    network = new()
                    {
                        ipClass = classType,
                    }; break;

                case "E":
                    network = new()
                    {
                        ipClass = classType,
                    }; break;

                default:
                    network = new()
                    {
                        ipClass = classType,
                    }; break;
            }

            FutureUse();
        }
        
        private void FutureUse()
        {
            VarGeneric.varnetwork = network;
        }


        public string ToStringValues()
        {
            if (network != null && address?.w != null && address?.x != null && address?.y != null && address?.z != null)
            {
                string message =
                    $"Clase de IP: {network.ipClass}\n" +
                    $"Mascara de red: {(network.networkMask != null ? network.networkMask.ToString() : "No definido")}\n" +
                    $"ID de red: {(network.networkId != null ? network.networkId.ToString() : "No definido")}\n" +
                    $"ID de host: {(network.hostId != null ? network.hostId.ToString() : "No definido")}\n" +
                    $"IP de red: {(network.networkIp != null ? network.networkIp.ToString() : "No definido")}\n" +
                    $"IP de host: {(network.hostIp != null ? network.hostIp.ToString() : "No definido")}\n" +
                    $"Bits de ID de red: {(network.bitsNetworkId != null ? network.bitsNetworkId.ToString() : "No definido")}\n" +
                    $"Bits de ID de host: {(network.bitsHostId != null ? network.bitsHostId.ToString() : "No definido")}\n" +
                    $"Broadcast: {(network.broadcast != null ? network.broadcast.ToString() : "No definido")}\n" +
                    $"Número de redes: {network.numberNetworks}\n" +
                    $"Número de redes utilizables: {network.numberUsableNetworks}\n";

                if (network.ipClass == "D")
                {
                    message =
                        $"Clase de IP: {network.ipClass}\n" + 
                        $"Esta clase es de Dirección multicast.";
                }

                if (network.ipClass == "E")
                {
                    message =
                        $"Clase de IP: {network.ipClass}\n" +
                        $"Esta clase son direcciones reservadas para uso futuro";
                }

                if (network.ipClass == "I")
                {
                    message =
                        $"Dirección IP: {address}\n" +
                        $"La dirección 0.0.0.0 es utilizada por las máquinas cuando están arrancando.";
                }

                if (network.ipClass == "L")
                {
                    message =
                        $"Dirección IP: {address}\n" +
                        $"Las direcciones 127.x.x.x se reservan para pruebas de retroalimentación.\n" +
                        $"Se denomina dirección de bucle local o loopback. ";
                }

                return message;
            }
            else
            {
                return "Direccion IP no válido";
            }
        }
        
        
        public string ToJson()
        {
            string json;
            if (network != null && address?.w != null && address?.x != null && address?.y != null && address?.z != null)
            {
                json = JsonSerializer.Serialize(new
                {
                    ipClass = network.ipClass,
                    networkMask = network.networkMask?.ToString(),
                    networkId = network.networkId?.ToString(),
                    hostId = network.hostId?.ToString(),
                    networkIp = network.networkIp?.ToString(),
                    hostIp = network.hostIp?.ToString(),
                    bitsNetworkId = network.bitsNetworkId?.ToString(),
                    bitsHostId = network.bitsHostId?.ToString(),
                    broadcast = network.broadcast?.ToString(),
                    numberNetworks = network.numberNetworks,
                    numberUsableNetworks = network.numberUsableNetworks
                });

                return json;
            }
            else
            {
                return "{\"error\": \"Dirección IP no válida\"}";
            }
        }
    }
}
