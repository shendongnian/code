    public void caesarcipher()
    {
        string PT = textBox1.Text;
        PT = PT.ToLower();
        char c;
        char[] a = new char[PT.Length];
        for (int i = 0; i < PT.Length; i++)
        {
            c = Convert.ToChar(PT.Substring(i, 1));
            if ((int)c + 3 > 122) a[i] = (char)(c + 3 - 26);
            else a[i] = (char)(c + 3); 
        }
        label2.Text = new string(a);
    }
    
    private void button1_Click(object sender, EventArgs e)
    {
        caesarcipher();
    }
