    using Word = Microsoft.Office.Interop.Word;
 
     var wordApp = new Word.Application();
                wordApp.Visible = false;
            try
            {
                
                var wordDocument = wordApp.Documents.Open(TemplateFileName);
                ReplaceWordStub("{ILL}", dataGridView3.CurrentRow.Cells[3].Value.ToString(), wordDocument);
                pictureBoxTgt.Image.Save(@"C:\Template\1.jpg", ImageFormat.Jpeg);
                string fileName = @"C:\Template\1.jpg";
                Object oMissed = wordDocument.Paragraphs[1].Range; 
                Object oLinkToFile = false;  
                Object oSaveWithDocument = true;
                wordDocument.InlineShapes.AddPicture(fileName, ref oLinkToFile, ref oSaveWithDocument, ref oMissed);
                wordDocument.SaveAs(@"C:\Result\" + name +  ".doc");
                wordDocument.Close();
                
            }
            catch
            {
                MessageBox.Show("Error!");
            }
            finally
            {
                wordApp.Quit();
            }
            File.Delete(@"C:\Template\1.jpg");
