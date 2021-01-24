    using System;
    using System.Windows.Forms;
    namespace WindowsFormsApp1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                checkComboBox1.Items.Add(new CheckComboBoxItem("One", true));
                checkComboBox1.Items.Add(new CheckComboBoxItem("Two", true));
                checkComboBox1.Items.Add(new CheckComboBoxItem("Three", true));
                this.checkComboBox1.CheckStateChanged += new EventHandler(this.checkComboBox1_CheckStateChanged);
            }
            private void checkComboBox1_CheckStateChanged(object sender, EventArgs e)
            {
                if (sender is CheckComboBoxItem)
                {
                    CheckComboBoxItem item = (CheckComboBoxItem)sender;
                }
            }
        } 
    }
