            try
            {
                if (!string.IsNullOrEmpty(textBox2.Text))
                {
                    int val1 = Convert.ToInt32(textBox1.Text);
                    int val2=Convert.ToInt32(textBox2.Text);
                    int result = val1 - val2;
                    txtResult.Text = result.ToString();
                }
                else if (String.IsNullOrEmpty(textBox2.Text))
                {
                    MessageBox.Show("Enter A Amount Please !!");
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
