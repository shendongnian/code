    private void btnCreateClaim_Click(object sender, EventArgs e)
    {
        Excel.Application oXL;
        Excel._Workbook oWB;
        Excel._Worksheet oSheet;
        oXL = new Excel.Application();
        oXL.Visible = true;
        oWB = oXL.Application.Workbooks.Open(@"C:\CSAIO4D\testsheet1.xlsx");
        oSheet = oWB.ActiveSheet;
        int inc = 1;
        while(oSheet.Cells[inc,1] != null)
        {
            inc++;
        }
        oSheet.Cells[inc, 1] = txtClientName.Text.ToString();
        oSheet.Cells[inc, 2] = txtState.Text.ToString();
        // etc...
        oWB.Save();
    }
