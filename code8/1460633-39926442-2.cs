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
                        bool afterTableSplit = false;
                        if (paragraph.Next().Range.Tables.Count > 0)
                        {
                            //add dummy row to the table
                            object firstRow = paragraph.Next().Range.Tables[1].Rows[1];
                            firstRow = paragraph.Next().Range.Tables[1].Rows.Add(ref firstRow);
                            //split the table after the dummy row
                            paragraph.Next().Range.Tables[1].Split(2);
                            //delete the dummy row table
                            paragraph.Next().Range.Tables[1].Delete();
                            afterTableSplit = true;
                        }
                        paragraph.Range.InsertParagraphAfter();
                        paragraph.Next().Range.Text = "New Text";
                        if (!afterTableSplit) paragraph.Next().Range.Text += "\r\n";
                        paragraph.Next().Reset();
                        paragraph.Next().set_Style("Normal");
                    }
                }
                doc.Save();
                doc.Close();
        
            }
        }
    }
