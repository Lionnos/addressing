using LogicLayer.Analyze;

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

            int amount = int.Parse(textBoxSubnet.Text);
            if (amount >= 2)
            {
                Subnets subnets = new Subnets(amount);
                labelResultSubnet.Text = subnets.ToStringValues();
            }
        }
    }
}
