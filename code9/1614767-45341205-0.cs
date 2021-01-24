    if (textBox1.Text == string.Empty && textBox2.Text == string.Empty && textBox3.Text == string.Empty && textBox4.Text == string.Empty)
            {
                MessageBox.Show("All fields are empty, try again!");
            }
            else if (textBox1.Text != string.Empty && textBox2.Text != string.Empty && textBox3.Text != string.Empty && textBox4.Text != string.Empty)
            {
                string a = textBox1.Text;
                string b = textBox2.Text;
                string c = textBox3.Text;
                string d = textBox4.Text;
    
                if (txtmessagechanged != null)
                {                
                    int ai = 0;
                    int bi = 0;
                    int ci = 0;
                    int di = 0;
    
                    if(int.TryParse(a, out ai) && int.TryParse(b, out bi) && int.TryParse(c, out ci) && int.TryParse(d, out di))
                    {
                        int result = ai + bi + ci + di;
                        txtmessagechanged("Your total is " + result.ToString(), null);
                    }           
                }
        }
