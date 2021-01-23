                //open the document.
                doc = app.Documents.Open(sourceFolderAndFile, ReadOnly: true, ConfirmConversions: false);
                //create a word app.
                var wordApp = (MsWord.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Word.Application");
                //iterate through the tables and delete them.
                foreach (MsWord.Table table in doc.Tables)
                {
                    //select the area where the table is located and delete it.
                    MsWord.Range rng = table.Range;
                    rng.SetRange(table.Range.End, table.Range.End);
                    table.Delete();
                }
                //don't forget doc.close and app.quit to clean up memory.
