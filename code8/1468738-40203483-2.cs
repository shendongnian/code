     private void button1_Click(object sender, EventArgs e)
            {   listBox1.Items.Clear();
                foreach (var item in dogs)
                {
                    string text = "Hello. I am a " + item.BreedName + ". " + item.BarkingSound + "etc";
                    listBox1.Items.Add(text);
                }
            }
