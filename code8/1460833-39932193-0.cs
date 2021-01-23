    public Form1()
        {
            rB1.CheckedChanged += new EventHandler(rB_CheckedChanged);
            rB2.CheckedChanged += new EventHandler(rB_CheckedChanged);
        
            
        }
        
        private void rB_CheckedChanged (object sender, EventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
        
            if (radioButton1.Checked)
            {
               
            }
            else if (radioButton2.Checked)
            {
                
            }
        }
