     public void GetColorText()
        {
            string output = String.Empty;
            object missObj = Missing.Value;
            object path = @"C:\Users\Mateusz\Desktop\test.docx";
            Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
            Microsoft.Office.Interop.Word.Document doc = app.Documents.Open(ref path, ref missObj, ref missObj,
                ref missObj, ref missObj, ref missObj, ref missObj, ref missObj, ref missObj, ref missObj, ref missObj,
                ref missObj, ref missObj, ref missObj, ref missObj, ref missObj);
            foreach (Microsoft.Office.Interop.Word.Range range in doc.Words)
            {
                if (range.HighlightColorIndex == Microsoft.Office.Interop.Word.WdColorIndex.wdYellow)
                {
                    output += $"{range.Text} ";
                }
            }
            Console.WriteLine(output);
        }
