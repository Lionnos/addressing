using LogicLayer.Analyze;
using LogicLayer.Generic;
using System.Windows.Forms;

namespace FormLayer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonAnalyze_Click(object sender, EventArgs e)
        {
            string ip = textBoxIP.Text;
            Classification classification = new Classification(ip);
            labelResult.Text = classification.ToStringValues();
            //textBoxIP.Text = "";

            try
            {
                int amount = int.Parse(textBoxSubnet.Text);

                if (amount >= 2)
                {
                    Subnets subnets = new Subnets(amount);
                    labelResultSubnet.Text = subnets.ToStringValues();
                }

                tables(amount);
            }
            catch (FormatException)
            {
                labelResultSubnet.Text = "Cantidad de subredes inválida";
            }
        }

        private void tables(int amount) 
        {
            dataGridViewConfiguration();

            if (amount > 1)
            {
                ListSubnets listSubnet = new ListSubnets();

                Address[][] listresult = listSubnet.matrix();

                for (int i = 0; i < listresult.Length; i++)
                {
                    string[] row = new string[5];
                    row[0] = (i).ToString();
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            if (listresult[i][j] != null)
                            {
                                row[j+1] = listresult[i][j].ToString();
                            }
                            else
                            {
                                row[j+1] = "-";
                            }

                        }
                    }
                    dataGridView.Rows.Add(row);

                    if (i == 0)
                    {
                        dataGridView.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
                    }
                    if (i == listresult.Length - 1)
                    {
                        dataGridView.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
                    }
                }
            }
        }

        private void dataGridViewConfiguration()
        {
            dataGridView.ColumnCount = 5;
            dataGridView.Columns[0].Name = "Número";
            dataGridView.Columns[1].Name = "IP de subred";
            dataGridView.Columns[2].Name = "Primera ip configurable";
            dataGridView.Columns[3].Name = "Ultima ip configurable";
            dataGridView.Columns[4].Name = "Broadcast";
            // Define el ancho de cada columna
            dataGridView.Columns[0].Width = 60;
            dataGridView.Columns[1].Width = 120;
            dataGridView.Columns[2].Width = 120;
            dataGridView.Columns[3].Width = 120;
            dataGridView.Columns[4].Width = 120;

            foreach (DataGridViewColumn col in dataGridView.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dataGridView.Rows.Clear();
        }
    }
}
