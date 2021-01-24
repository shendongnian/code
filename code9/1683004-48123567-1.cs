        private void btnCreateClaim_Click(object sender, EventArgs e)
        {
            Excel.Application oXL;
            Excel._Workbook oWB;
            Excel._Worksheet oSheet;
            oXL = new Excel.Application();
            oXL.Visible = true;
            oWB = oXL.Application.Workbooks.Open(@"C:\CSAIO4D\testsheet1.xlsx");
            oSheet = oWB.ActiveSheet;
            int inc = FindFirstBlankRow(oSheet);
            oSheet.Cells[inc, 1] = txtClientName.Text.ToString();
            oSheet.Cells[inc, 2] = txtState.Text.ToString();
            oSheet.Cells[inc, 3] = txtAlphaPrefix.Text.ToString();
            oSheet.Cells[inc, 4] = txtInsurance.Text.ToString();
            oSheet.Cells[inc, 5] = txtStartDate.Text.ToString();
            oSheet.Cells[inc, 6] = txtEndDate.Text.ToString();
            oSheet.Cells[inc, 7] = txtUnits.Text.ToString();
            oSheet.Cells[inc, 8] = txtLOC.Text.ToString();
            oSheet.Cells[inc, 9] = txtRate.Text.ToString();
            oSheet.Cells[inc, 10] = txtAmount.Text.ToString();
            oSheet.Cells[inc, 11] = txtAuth.Text.ToString();
            oSheet.Cells[inc, 12] = txtBilledDate.Text.ToString();
            oSheet.Cells[inc, 13] = txtPrimaryDiagnosis.Text.ToString();
            oSheet.Cells[inc, 14] = txtBillType.Text.ToString();
            oSheet.Cells[inc, 15] = txtRevenueCode.Text.ToString();
            oSheet.Cells[inc, 16] = txtHCPCS.Text.ToString();
            oSheet.Cells[inc, 17] = txtCPT_Code.Text.ToString();
            oWB.Save();
        }
