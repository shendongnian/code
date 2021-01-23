              try
                {
                  book.Close();
                  Marshal.ReleaseComObject(book);
                  wb.Close();
                  Marshal.ReleaseComObject(wb);
                  _ExcelApp.Quit();
                  Marshal.FinalReleaseComObject(_ExcelApp);
                }
            catch (Exception) { }
                _ExcelApp = null;
        }
