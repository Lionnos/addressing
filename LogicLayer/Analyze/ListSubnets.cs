
using LogicLayer.Generic;

namespace LogicLayer.Analyze
{
    public class ListSubnets
    {
        SubNetwork? subNetwork;
        Network? network;
        Address[][] address;

        private int row;
        private int jump;
        private int? configurableips;

        public ListSubnets()
        {
            subNetwork = VarGeneric.varsubnetwork;
            network = VarGeneric.varnetwork;
            initvalues();
        }


        private void initvalues()
        {
            row = (int)subNetwork.number;
            jump = (int)subNetwork.jumps;
            configurableips = subNetwork.numberIpsUsable;
        }

        public Address[][] matrix()
        {
            switch(network?.ipClass)
            {
                case "A": matrixA(); break; 
                case "B": matrixB(); break; 
                case "C": matrixC(); break;
            }
            return address;
        }
        private void matrixA()
        {
            address = new Address[row][];
            Address? value = subNetwork?.ipNetwork;

            for (int i = 0; i < row; i++)
            {
                address[i] = new Address[4];
                address[i][0] = value;
                value = new Address { w = value?.w, x = value?.x + jump, y = value?.y, z = value?.z };
            }

            for (int i = 0; i < row; i++)
            {
                Address? j = address[i][0];
                address[i][1] = new Address { w = j.w, x = j.x, y = j.y, z = j.z + 1 };
            }

            for (int i = 0; i < row; i++)
            {
                Address? j = address[i][0];
                address[i][2] = new Address { w = j.w, x = j.x + jump - 1, y = j.y, z = 254 };
            }

            for (int i = 0; i < row; i++)
            {
                Address? j = address[i][0];
                address[i][3] = new Address { w = j.w, x = j.x + jump - 1, y = j.y, z = 255 };
            }
        }

        private void matrixB()
        {
            address = new Address[row][];
            Address? value = subNetwork?.ipNetwork;

            for (int i = 0; i < row; i++)
            {
                address[i] = new Address[4];
                address[i][0] = value;
                value = new Address { w = value?.w, x = value?.x, y = value?.y +jump, z = value?.z };
            }

            for (int i = 0; i < row; i++){
                Address? j = address[i][0];
                address[i][1] = new Address { w = j.w, x = j.x, y = j.y, z = j.z + 1};
            }

            for (int i = 0; i < row; i++)
            {
                Address? j = address[i][0];
                address[i][2] = new Address { w = j.w, x = j.x, y = j.y + jump - 1, z = 254 };
            }

            for (int i = 0; i < row; i++)
            {
                Address? j = address[i][0];
                address[i][3] = new Address { w = j.w, x = j.x, y = j.y + jump - 1, z = 255 };
            }
        }

        private void matrixC()
        {
            address = new Address[row][];

            Address? value = subNetwork?.ipNetwork;
            for (int i = 0; i < row; i++)
            {
                address[i] = new Address[4];
                address[i][0] = value;
                value = new Address { w = value?.w, x = value?.x, y = value?.y, z = value?.z + jump };
            }

            for (int i = 0; i < row; i++)
            {
                Address? j = address[i][0];
                address[i][1] = new Address { w = j.w, x = j.x, y = j.y, z = j.z + 1 };
            }

            for (int i = 0; i < row; i++)
            {
                Address? j = address[i][0];
                address[i][2] = new Address { w = j.w, x = j.x, y = j.y, z = j.z + configurableips };
            }

            for (int i = 0; i < row; i++)
            {
                Address? j = address[i][0];
                address[i][3] = new Address { w = j.w, x = j.x, y = j.y, z = j.z + configurableips + 1 };
            }
        }
    }
}
