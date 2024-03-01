
namespace LogicLayer.Generic
{
    public class Address
    {
        public int? w { get; set; }
        public int? x { get; set; }
        public int? y { get; set; }
        public int? z { get; set; }

        public override string ToString()
        {
            return $"{w}.{x}.{y}.{z}";
        }
    }


    public class AddresssBits
    {
        public string? w { get; set; }
        public string? x { get; set; }
        public string? y { get; set; }
        public string? z { get; set; }

        public override string ToString()
        {
            return $"{w}.{x}.{y}.{z}";
        }
    }

}
