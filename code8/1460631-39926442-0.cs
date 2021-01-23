    using Microsoft.Office.Interop.Word;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace ConsoleApplication7
    {
        class Program
        {
            static void Main(string[] args)
            {
                Application app = new Application();
                var doc = app.Documents.Open(@"C:\users\mhainc\desktop\test.docx");
                
                foreach (Microsoft.Office.Interop.Word.Paragraph paragraph in doc.Paragraphs)
                {
                    if (paragraph.get_Style() != null && paragraph.get_Style().NameLocal == "Heading 2")
                    {
                        paragraph.Range.InsertParagraphAfter();
                        paragraph.Next().Range.Text = "New Text\r\n";
                        paragraph.Next().Reset();
                        paragraph.Next().set_Style("Normal");
                        
                    }
                }
                doc.Save();
                doc.Close();
        
            }
        }
    }
