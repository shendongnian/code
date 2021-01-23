    static void Main(string[] args)
    {
      List<string> data = new List<string>();
      Application app = new Application();
      Document doc = app.Documents.Open(@"C:\temp\test.DOC");
      string testRows = "Test 1\n\tTest 2\tName\tAmount\nTest 3\nTest 4\nTest 5\nTest 6\nTest 7\nTest 8\nTest 9\nTest 10\n";
      try
      {
        var x = doc.Paragraphs[16];
        x = doc.Paragraphs.Add(x.Range);
        x.Range.Text = testRows;
        doc.SaveAs2(@"C:\temp\test3.DOC");
        ((_Document)doc).Close();
        ((_Application)app).Quit();
      }
      catch (System.Runtime.InteropServices.COMException e)
      {
        ((_Document)doc).Close();
        ((_Application)app).Quit();
        Console.WriteLine("COMException: " +  e.StackTrace.ToString());
        Console.ReadKey();
      }
    }
