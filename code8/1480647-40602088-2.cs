    static void Main(string[] args)
    {
      List<string> data = new List<string>();
      Application app = new Application();
      Document doc = app.Documents.Open(@"C:\temp\test.DOC");
      foreach (Paragraph objParagraph in doc.Paragraphs)
      {
        data.Add(objParagraph.Range.Text.Trim());
      }
     
      string tabRow = "\tName\tID\tAmount\n";
      var x = doc.Paragraphs[15];
      x.Range.Text = x.Range.Text + "\n" + tabRow;
      foreach (string curString in data)
      {
        var pText = doc.Paragraphs.Add(x.Range);
        pText.Range.Text = curString + "*\n";
      }
      doc.SaveAs2(@"C:\temp\test3.DOC");
      ((_Document)doc).Close();
      ((_Application)app).Quit();
    } 
