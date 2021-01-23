        List<int> myNumbers = new List<int>();
        private void button1_Click(object sender, EventArgs e)
        {
            foreach (string str in textBox1.Text.Split(' '))
            {
                if (int.TryParse(str, out i))
                    myNumbers.Add(int.Parse(str));
            }
        }
