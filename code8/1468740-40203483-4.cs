     private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (textBox1.Text != "")
                {
                    Dog TempDog = dogs.ElementAt(listBox1.SelectedIndex);
                    TempDog.BarkingSound = textBox1.Text;
                }
              
            }
