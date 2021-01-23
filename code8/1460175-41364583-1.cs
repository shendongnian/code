    using System.Drawing;
    using Spire.Doc;
    using Spire.Doc.Documents;
    
    namespace WordImage
    {
        class ImageinWord
        {
            static void Main(string[] args)
            {
                //Create Document
                Document document = new Document();
                document.LoadFromFile(@"E:\Work\Documents\WordDocuments\References.docx");
    
                TextSelection[] text = document.FindAllString("forming", false, true);
                foreach (TextSelection seletion in text)
                {
                    seletion.GetAsOneRange().CharacterFormat.HighlightColor = Color.Yellow;
                }
    
                document.SaveToFile("FindHighlight.docx", FileFormat.Docx);
                System.Diagnostics.Process.Start("FindHighlight.docx");
            }
        }
    }
