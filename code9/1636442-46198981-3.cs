     public static bool WordClass1(string doc,string sloc)
    
            {
       
                if (System.Runtime.InteropServices.Marshal.GetActiveObject("Word.Application") != null)
    
                {
    
                    Object oMissing = System.Reflection.Missing.Value;
    
                    Object oTrue = true;
       
                    Microsoft.Office.Interop.Word.Application oWordApp = (Microsoft.Office.Interop.Word.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Word.Application");
    
                    int i = 0;
                    i++;
                    string num = i.ToString();
                    Object oSaveAsFileWord = sloc;
                    foreach (Microsoft.Office.Interop.Word.Document document in oWordApp.Documents)
                    {
                        if (string.Equals(document.Name, doc))
                        {
                            Console.WriteLine("Found Document");
    
    
    
    
    
                            document.SaveAs(ref oSaveAsFileWord, ref oMissing, ref oMissing, ref oMissing,
                            ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                            ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                            ref oMissing, ref oMissing, ref oMissing, ref oMissing);
    
    
    
                            object doNotSaveChanges = Microsoft.Office.Interop.Word.WdSaveOptions.wdDoNotSaveChanges;
    
                            oWordApp.Document.Close(ref doNotSaveChanges, ref oMissing, ref oMissing);
                        }
    
                    }
