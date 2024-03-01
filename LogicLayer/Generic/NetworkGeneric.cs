
namespace LogicLayer.Generic
{
    public class Network
    {
        public string? ipClass { get; set; }       // Clase
        public Address? networkMask { get; set; }  // mascara de red
        public Address? networkId { get; set; }    // id de red
        public Address? hostId { get; set; }       // id de host
        public Address? networkIp { get; set; }    // ip de red
        public Address? hostIp { get; set; }       // ip de host
        public AddresssBits? bitsNetworkId { get; set; } // bits de red
        public AddresssBits? bitsHostId { get; set; }  // bits de host
              
        public Address? broadcast { get; set; }       // broadcast
        public int? numberNetworks { get; set; }      // numero de redes
        public int? numberUsableNetworks { get; set; }// numero de redes usables
    }


    public class SubNetwork
    {
        public Address? ipNetwork { get; set; }    // ip de red
        public int? borrowedBits { get; set; }     // bist prestados
        public int? number { get; set; }           // numero de subredes
        public int? numberUsable { get; set; }     // numero de subredes utilizables
        public int? numberIps { get; set; }        // numero de ips por subred
        public int? numberIpsUsables { get; set; } // numero de ips por subred utilizables
        public Address? mask { get; set; }         // mascara de la subred
        public AddresssBits? bitsMask { get; set; }// mascara de la subred en bits
        public int? jumps { get; set; }            // saltos
    }
}
