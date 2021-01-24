    private List<string> ContentList = new List<string>();
    private int Line = 1;
    private void button1_Click(object sender, EventArgs e)
    {
        ContentString = Convert.ToString(Line);       
        ContentList.Add(ContentString);
        System.IO.File.WriteAllLines(@"Test.txt",ContentList);
        Line = Line + 1;
    }
