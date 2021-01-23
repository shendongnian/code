     private void button2_Click(object sender, EventArgs e)
        {
            TabPage page = tabControl1.SelectedTab;
            var controls = page.Controls;
            foreach (var control in controls)
            {               
                if(control is TextBox)
                {
                  //do stuff
                }    
                if(control is ComboBox )
                {
                    ComboBox comboBox = (ComboBox)control;
                    if (comboBox.Items.Count > 0)
                        comboBox.SelectedIndex = 0;
                    comboBox.Text = string.Empty;
                }                
            }
        }
