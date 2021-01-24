    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace WindowsFormsApplication2
    {
        public partial class Form1 : Form
        {
            int comboboxIndex = 0;
            public Form1()
            {
                InitializeComponent();
                comboBox1.Items.Clear();
                for (int i = 2000; i < 2018; i++)
                {
                    comboBox1.Items.Add(i.ToString());
                }
                comboBox1.SelectedIndex = 0;
            }
            private void Previous_Click(object sender, EventArgs e)
            {
                if (comboboxIndex > 0)
                {
                    comboboxIndex--;
                    comboBox1.SelectedIndex = comboboxIndex;
                }
            }
            private void Next_Click(object sender, EventArgs e)
            {
                if (comboboxIndex < comboBox1.Items.Count - 1)
                {
                    comboboxIndex++;
                    comboBox1.SelectedIndex = comboboxIndex;
                }
            }
        }
    }
