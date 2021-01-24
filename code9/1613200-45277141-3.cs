    public void writeTxt()
    {
        string path = @"C:\Users\Morris\Desktop\test.txt";
        using (var tw = new StreamWriter(path, true))
        {
            tw.WriteLine(TextBox1.Text);
            tw.Close();
        }
    }
