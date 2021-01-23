    if(comboBox1.Text=="Suma")
            {
                decimal s = 0;
                decimal temp;
                for (int i = 0; i < numericUpDown1.Value; i++)
                {
                    var currentNumUpDown = this.panel1.Controls["numericUpDown" + (100 + i).ToString()] as NumericUpDown;
                    var currentNumUpDown2 = this.panel1.Controls["numericUpDown" + (200 + i).ToString()] as NumericUpDown;
                    currentNumUpDown.ValueChanged += new EventHandler(comboBox1_SelectedIndexChanged);
                    currentNumUpDown2.ValueChanged += new EventHandler(comboBox1_SelectedIndexChanged);
                    MessageBox.Show("executed");
                    temp = currentNumUpDown.Value * currentNumUpDown2.Value;
                    s = s + temp;
                }
