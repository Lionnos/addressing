

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

        public int DecimalToBinary(int decimalNumber)
        {
            int binaryNumber = 0;
            int factor = 1;

            while (decimalNumber > 0)
            {
                binaryNumber += (decimalNumber % 2) * factor;
                decimalNumber /= 2;
                factor *= 10;
            }

            while (factor <= 10000000)
            {
                binaryNumber *= 10;
                factor *= 10;
            }

            return binaryNumber;
        }


        public int BinaryToDecimal(string binaryNumber)
        {
            int decimalNumber = 0;

            for (int i = binaryNumber.Length - 1; i >= 0; i--)
            {
                if (binaryNumber[i] == '1')
                {
                    decimalNumber += (int)Math.Pow(2, binaryNumber.Length - 1 - i);
                }
            }

            return decimalNumber;
        }


        public AddressBits DecimalToBinaryVector(Address address)
        {
            AddressBits addressbits = new AddressBits();

            addressbits.w = DecimalToBinary((int)address.w).ToString();
            addressbits.x = DecimalToBinary((int)address.x).ToString();
            addressbits.y = DecimalToBinary((int)address.y).ToString();
            addressbits.z = DecimalToBinary((int)address.z).ToString();

            return addressbits;
        }

        public Address BinaryToDecimalVector (AddressBits addressbits)
        {
            Address address = new Address();

            address.w = BinaryToDecimal(addressbits.w);
            address.x = BinaryToDecimal(addressbits.x);
            address.y = BinaryToDecimal(addressbits.y);
            address.z = BinaryToDecimal(addressbits.z);

            return address;
        }


        public string generateOnes(int value)
        {
            if (value <= 0)
            {
                return new string('0', 8);
            }

            if (value >= 8)
            {
                return new string('1', value); 
            }
            else
            {
                return new string('1', value) + new string('0', 8 - value);
            }
        }

        public int CountOnes(string bitString)
        {
            int count = 0;
            foreach (char bit in bitString)
            {
                if (bit == '1')
                {
                    count++;
                }
            }
            return count;
        }
    }
}
