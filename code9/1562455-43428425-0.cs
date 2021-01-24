    using Microsoft.Office.Interop.Word;
    namespace ConsoleWord
    {
        class Program
        {
            static void Main(string[] args)
            {
                Document doc = new Document();
                for (int i = 0; i < 5; i++)
                {
                   var  range = doc.Range(0, 0);
                    object text = "test" + i;
                    object fieldType = WdFieldType.wdFieldAuthor;
                    Paragraph para = doc.Paragraphs.Add(range);
                    doc.Fields.Add(range, ref fieldType, ref text);
                }
                doc.SaveAs2(@"C:\tmpc\aa.docx");
            }
        }
    }
 
