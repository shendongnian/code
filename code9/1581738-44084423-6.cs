    private void textBox1_TextChanged(object sender, EventArgs e)
                    {
                        int a;
                        bool succes = int.TryParse(textBox1.Text, out a);
                        if(!succes)
                        {
                           MessageBox.Show("incorrect");
                           return;
                        }
                        if (a < 0 || a > 11)
                        {
                          MessageBox.Show("incorrect");
                        }
                        // ... Do stuff to a?
                    }
