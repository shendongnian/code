    using MsWord = Microsoft.Office.Interop.Word;
    private static void MsWordCopy()
        {
            var wordApp = new MsWord.Application();
            MsWord.Document documentFrom = null, documentTo = null;
            try
            {
                var fileNameFrom = @"C:\MyDocFile.docx";               
                                
                wordApp.Visible = true;
                
                documentFrom = wordApp.Documents.Open(fileNameFrom, Type.Missing, true);
                MsWord.Range oRange = documentFrom.Content;
                oRange.Copy();
                var fileNameTo = @"C:\MyDocFile-Copy.docx";
                documentTo = wordApp.Documents.Add();
                documentTo.Content.PasteSpecial(DataType: MsWord.WdPasteOptions.wdKeepSourceFormatting);
                documentTo.SaveAs(fileNameTo);              
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (documentFrom != null)
                    documentFrom.Close(false);
                if (documentTo != null)
                    documentTo.Close();
                if (wordApp != null)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(wordApp);
                wordApp = null;
                documentFrom = null;
                documentTo = null;
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }
