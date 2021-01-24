    private void button1_Click(object sender, EventArgs e)
    {
        SaveFileDialog savefile = new SaveFileDialog();
        if (savefile.ShowDialog() == DialogResult.OK)
        {
            xlWorkBook.SaveAs("" + savefile.FileName + ".xlsx");
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkBook);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkSheet);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);
            xlWorkSheet = null;
            xlWorkBook = null;
            xlApp = null;
            GC.Collect();
        }
    }
            
