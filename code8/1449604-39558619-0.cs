     string newPath = path.Replace(Path.GetFileNameWithoutExtension(path),Path.GetFileNameWithoutExtension(path)+"_Updated)";
     try{
        mWorkBook.SaveAs(newPath,Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive,Missing.Value,Missing.Value,Missing.Value,Missing.Value, Missing.Value);
       mWorkBook.Close(Missing.Value, Missing.Value, Missing.Value);
       File.Delete(path); 
       }
     catch(Exception e){
          Console.WriteLine(e.Message+"\n"+e.Source);
     }
