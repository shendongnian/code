    private Excel.Application Xls;
    private Excel.Workbooks XlsB;
    private Excel.Workbook WB;
    private Excel.Worksheet WS;
    private Excel.Sheets WBs;
    string lblPath = "SomePath";
    string txtTATW = "Some Text";
    private void btnPrint_Click(object sender, EventArgs e)
    {
      try
      {
        Xls = new Excel.Application();
        XlsB = Xls.Workbooks;
        WB = XlsB.Open(@"H:\ExcelTestFolder\TestAddData.xlsx", 0, false, 5, "", "", true,
            XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
        WBs = WB.Worksheets;
        WS = WBs.get_Item(1);
        WS.Cells[1, 1] = txtTATW;
        WB.Save();
      }
      catch (Exception ex)
      {
        MessageBox.Show("Write Excel: " + ex.Message);
      }
      finally
      {
        GC.Collect();
        GC.WaitForPendingFinalizers();
        WB.Close();
        Xls.Quit();
        releaseObject(WS);
        releaseObject(WBs);
        releaseObject(WB);
        releaseObject(XlsB);
        releaseObject(Xls);
      }
      MessageBox.Show("Finished Updating File");
    }
