    string A = textBox1.Text.Trim();
    if (A.Contains("|"))
        textBox2.Text = A.Replace("|", String.Empty);
    else
    {
        A = A.Replace("AB", "CD");
        A = A.Replace("GF", "HI");
        A = A.Replace("AC", "QW");
        A = A.Replace("VB", "GG");
        textBox2.Text = A;
    }
