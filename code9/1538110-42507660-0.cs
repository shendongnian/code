    xlWorkBook.SaveAs("" + saveasPath + ".xlsx");
                        
    xlWorkBook.Close(true, misValue, misValue);
                        
    xlApp.Quit();
    releaseObject(xlWorkBook);
    releaseObject(xlApp);
    releaseObject(xlWorkSheet);
    GC.Collect();
    xlWorkSheet = null;
    xlWorkBook = null;
    xlApp = null;
    
    Cursor.Current = Cursors.Default;
    Process.Start("" + saveasPath + ".xlsx");
    private void releaseObject(object obj)
    {
      try
      {
        System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
        obj = null;
      }
      catch (Exception ex)
      {
        obj = null;
        MessageBox.Show(ex.Message);
      }
      finally
      {
       GC.Collect();
      }
    }
