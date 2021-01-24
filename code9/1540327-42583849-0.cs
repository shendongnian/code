    private void button1_Click(object sender, EventArgs e)
    {
        string numofitems = textBox1.Text;
        int x = 0;
        if (Int32.TryParse(numofitems, out x) && x > 0 && x <= 5)
        {
            //it is valid
        }
    }
