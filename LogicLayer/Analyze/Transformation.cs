

using LogicLayer.Generic;

namespace LogicLayer.Analyze
{
    internal class Transformation
    {
        public Address ipObtain(string ip)
        {
            Address address = new Address();

            if (IsValidIp(ip))
            {
                string[] octets = ip.Split('.');

                address.w = int.Parse(octets[0]);
                address.x = int.Parse(octets[1]);
                address.y = int.Parse(octets[2]);
                address.z = int.Parse(octets[3]);
            }

            return address;
        }


        private static bool IsValidIp(string ip)
        {
            string[] octets = ip.Split('.');

            if (octets.Length != 4) return false;

            foreach (string octet in octets)
            {
                if (!int.TryParse(octet, out int value) || value < 0 || value > 255)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
