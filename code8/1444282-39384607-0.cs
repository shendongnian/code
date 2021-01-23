    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Office.Interop.Word;
    using System.Runtime.InteropServices;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var app = new Microsoft.Office.Interop.Word.Application();
                var sourceDoc =    app.Documents.Open(@"D:\test.docx");
                sourceDoc.ActiveWindow.Selection.WholeStory();
                sourceDoc.ActiveWindow.Selection.Copy();
                var newDocument = new Microsoft.Office.Interop.Word.Document();
                newDocument.ActiveWindow.Selection.Paste();
                newDocument.SaveAs(@"D:\test1.docx");
                sourceDoc.Close(false);
                newDocument.Close();
                app.Quit();
                Marshal.ReleaseComObject(app);
                Marshal.ReleaseComObject(sourceDoc);
                Marshal.ReleaseComObject(newDocument);
            }
        }
    }
