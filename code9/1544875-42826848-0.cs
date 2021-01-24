    System.IO.FileStream fs = new FileStream(pathSource, FileMode.OpenOrCreate, FileAccess.ReadWrite);
     string fileName = fs.Name;
     try
     {
         workbook.Save(fs);
     }
     catch (Exception ex)
     {                      
         Logger.Error(" Error:", ex);
     }
     finally
     {                       
         workbook.Close();
     }
