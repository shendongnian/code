    using System;
    using System.Linq;
    using System.Windows.Forms;
    
    namespace WindowsFormsApp1
    {
        public partial class Form1 : Form
        {
            public double SubTotal { get; set; }
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                comboBoxBeverage.Items.Add("");
                comboBoxBeverage.Items.Add("Soda $1.95");
                comboBoxBeverage.Items.Add("Tea $1.50");
                comboBoxBeverage.Items.Add("Coffee $1.25");
                comboBoxBeverage.Items.Add("Mineral Water $2.95");
                comboBoxBeverage.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBoxBeverage.SelectedIndex = 0;
            }
    
            private void Button1_Click(object sender, EventArgs e)
            {                     
                var itemPrice = comboBoxBeverage.Text.Split('$').Skip(1).FirstOrDefault();
                SubTotal += double.Parse(itemPrice);
                labelSubtotal.Text = "$" + SubTotal;
            }
        }
    }
