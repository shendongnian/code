    private void button1_Click(object sender, EventArgs e)
    {
        System.IO.File.AppendAllText(@"Test.txt", Line.ToString() + Environment.NewLine);
        Line = Line + 1;
    }
