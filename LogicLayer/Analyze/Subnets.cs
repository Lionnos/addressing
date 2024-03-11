
using LogicLayer.Generic;

namespace LogicLayer.Analyze
{
    public class Subnets
    {
        private int numberSubnetInput;
        private Network? network;
        private SubNetwork? subnetwork;
        private Transformation transformation;

        private int bits = 1;
        private int numbersubnets = 2;
        private int numberips = 0;
        Address fathermask = new Address { w = 0, x = 0, y = 0, z = 0 };
        Address submask = new Address { w = 0, x = 0, y = 0, z = 0 };
        AddressBits addressBits = new AddressBits { w = "", x ="", y ="", z ="" };
        private int? ones;
        private int jumps = 0;

        public Subnets(int numberSubnets)
        {
            this.numberSubnetInput = numberSubnets;
            network = VarGeneric.varnetwork;
            transformation = new Transformation();

            CalculateBitsIps();
            CalculateBitsMask();
            CalculateSubMaskandJump();
            AsignedSubnets();
        }


        private void CalculateBitsIps()
        {
            while (numbersubnets < numberSubnetInput)
            {
                bits++;
                numbersubnets = (int)Math.Pow(2, bits) - 2;
            }

            switch (network?.ipClass)
            {
                case "A": numberips = (int)Math.Pow(2, (24 - bits)); break;
                case "B": numberips = (int)Math.Pow(2, (16 - bits)); break;
                case "C": numberips = (int)Math.Pow(2, (8 - bits)); break;
            }
        }


        private void CalculateBitsMask()
        {
            fathermask = network.Mask;
            addressBits = transformation.DecimalToBinaryVector(fathermask);

            switch (network?.ipClass)
            {
                case "A":
                    switch (bits)
                    {
                        case <= 8:
                            addressBits.x = transformation.generateOnes(bits);
                            break;
                        case <= 16:
                            addressBits.x = transformation.generateOnes(8);
                            addressBits.y = transformation.generateOnes(bits - 8);
                            break;
                        case <= 24:
                            addressBits.x = transformation.generateOnes(8);
                            addressBits.y = transformation.generateOnes(8);
                            addressBits.z = transformation.generateOnes(bits - 16);
                            break;
                    }
                    break;

                case "B":
                    switch (bits)
                    {
                        case <= 8:
                            addressBits.y = transformation.generateOnes(bits);
                            break;
                        case <= 16:
                            addressBits.y = transformation.generateOnes(8);
                            addressBits.z = transformation.generateOnes(bits - 8);
                            break;
                    }
                    break;

                case "C":
                    addressBits.z = transformation.generateOnes(bits);
                    break;
            }
        }

        private void CalculateSubMaskandJump()
        {
            submask = transformation.BinaryToDecimalVector(addressBits);
            AddressBits value = addressBits;

                 ones = (transformation.CountOnes(value.w) +
                 transformation.CountOnes(value.x) +
                 transformation.CountOnes(value.y) +
                 transformation.CountOnes(value.z));

            jumps = 256 / (numbersubnets + 2);
        }


        private void AsignedSubnets() 
        {
            subnetwork = new()
            {
                ipNetwork = network?.networkIp,
                borrowedBits = bits,
                number = numbersubnets + 2,
                numberUsable = numbersubnets,
                numberIps = numberips,
                numberIpsUsable = numberips - 2,
                mask = submask,
                CIDR = ones,
                bitsMask = addressBits,
                jumps = jumps
            };

            VarGeneric.varsubnetwork = subnetwork;
        }

        public string ToStringValues()
        {
            if (subnetwork != null)
            {
                string message =
                    $"IP de red: {subnetwork.ipNetwork}\n" +
                    $"Bist prestados: {(subnetwork.borrowedBits != null ? subnetwork.borrowedBits : "")}\n" +
                    $"Nro total de subredes: {(subnetwork.number != null ? subnetwork.number: "")}\n" +
                    $"Nro total de subredes utilizables: {(subnetwork.numberUsable != null ? subnetwork.numberUsable : "")}\n" +
                    $"Nro total de ips por subred: {(subnetwork.numberIps != null ? subnetwork.numberIps : "")}\n" +
                    $"Nro total de ips por subred utilizables: {(subnetwork.numberIpsUsable != null ? subnetwork.numberIpsUsable : "")}\n" +
                    $"Mascara de la subred: {(subnetwork.mask != null ? subnetwork.mask.ToString() +" / "+ subnetwork.CIDR : "")}\n" +
                    $"Mascara de la subred en bits: {(subnetwork.bitsMask != null ? subnetwork.bitsMask.ToString() : "")}\n" +
                    $"Saltos en subred: {(subnetwork.jumps != null ? subnetwork.jumps: "")}";

                return message;
            }
            else
            {
                return "Cantidad de subredes inválida.";
            }
        }
    }

}
