     private void button1_Click(object sender, EventArgs e)
            {
                string [] array = { "a", "b", "c", "d" };
                int vcounter = 0;
                foreach (var item in array)
                {
                    if (item.Contains("a") || item.Contains("e") || item.Contains("i")) //You can add the other volwes 
                    {
                        vcounter++;
                    }
                }
                MessageBox.Show("Count of vowels : " + vcounter.ToString());
            }
