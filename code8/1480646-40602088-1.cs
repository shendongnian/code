    static void Main(string[] args)
    {
      //var FileName = @"C:\temp\test.DOC";
      List<string> data = new List<string>();
      Application app = new Application();
      Document doc = app.Documents.Open(@"C:\temp\test.DOC");
      //foreach (Paragraph objParagraph in doc.Paragraphs)
      //{
      //  data.Add(objParagraph.Range.Text.Trim());
      // }
      //data.Insert
      //data.Insert(16, "Test 1");
      //data.Insert(16, "\tTest 2\tName\tAmount");
      //data.Insert(16, "Test 3");
      //data.Insert(16, "Test 4");
      //data.Insert(16, "Test 5");
      //data.Insert(16, "Test 6");
      //data.Insert(16, "Test 7");
      //data.Insert(16, "Test 8");
      //data.Insert(16, "Test 9");
      //data.Insert(16, "Test 10");
      string tabRow = "Test 1\tTest 2\tTest 3\tTest 4\tTest 5\tTest 6\tTest 7\tTest 8\tTest 9\tTest 10\n";
      //var x = doc.Paragraphs.Add();
      //x.Range.Text = "\tTest 2\tName\tAmount";
     
      var x = doc.Paragraphs[15];
      x.Range.Text = x.Range.Text + "\n" + tabRow;
      
      doc.SaveAs2(@"C:\temp\test3.DOC");
      ((_Document)doc).Close();
      ((_Application)app).Quit();
    }
  
