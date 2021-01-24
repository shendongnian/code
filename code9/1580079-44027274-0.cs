                object oMissing = System.Reflection.Missing.Value;
                object oEndOfDoc = "\\endofdoc"; /* \endofdoc is a predefined bookmark */
    
                //Start Word and create a new document.
                Microsoft.Office.Interop.Word._Application oWord;
                Microsoft.Office.Interop.Word._Document oDoc;
                oWord = new Microsoft.Office.Interop.Word.Application();
                oWord.Visible = false;
                oDoc = oWord.Documents.Add(ref oMissing, ref oMissing,
                ref oMissing, ref oMissing);
    
                oDoc.Content.SetRange(0, 0);
                oDoc.Content.Text = "String text;
    
                object filename = @"c:\temp1.docx";
                oDoc.SaveAs2(ref filename);
                oDoc.Close(ref oMissing, ref oMissing, ref oMissing);
                oDoc = null;
                oWord.Quit(ref oMissing, ref oMissing, ref oMissing);
                oWord = null;
