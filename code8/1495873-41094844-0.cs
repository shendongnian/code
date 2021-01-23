    public int Value1
    {
        get
        {
            int value = 0;
            int.TryParse(textBox1.Text.Trim(), out value);
            return value;
        }
     }
