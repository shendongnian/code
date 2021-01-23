        List<int> myNumbers = new List<int>();
        private void button1_Click(object sender, EventArgs e)
        {
            int i;
            if (int.TryParse(textBox1.Text, out i)) 
                myNumbers.Add(int.Parse(textBox1.Text)); 
        }
