        public string Capacity(double DWT, string shipType)
        {
            double cap;
            switch (shipType)
            {
                case "CON":
                    cap = 0.7 * DWT;
                    break;
                default:
                    cap = DWT;
                    break;
            }
            string c = cap.ToString();
            return c;
        }
    }
    public partial class Form1 : Form
    {
        Calculations cal = new Calculations();
        public Form1()
        {
            InitializeComponent();
        }
        public void btnCalculate_Click(object sender, EventArgs e)
        {
            groupBoxResult.Visible = true;
            double dwt = Convert.ToDouble(textDWT.Text);
            textShipType.Text = cal.Capacity(dwt, textShipType.Text);
        }
    }
