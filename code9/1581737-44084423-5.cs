       private void textBox1_TextChanged(object sender, EventArgs e)
                {
                    int a;
                    
                try
                {
                    a = Convert.ToInt32(textBox1.Text);
                    
                }
                catch(Exception exc){
                   MessageBox.Show("incorrect exception thrown");
                }
                    if (textBox1.Text == null)
                    {
                        MessageBox.Show("incorrect");
                    }
                    else
                        if (a < 0 || a > 11)
                    {
                        MessageBox.Show("incorrect");
                    }
                }
