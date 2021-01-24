    static void Main(string[] args)
    {
        string filename = "test.docx";
        ReplaceInDocx(filename, "...", "15000");
    }
    static void ReplaceInDocx(string filename, string toReplace, string replacement)
    {
        var doc = DocX.Load(filename);
        doc.ReplaceText(toReplace, replacement);
        doc.Save();
    }
