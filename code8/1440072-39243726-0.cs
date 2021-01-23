    // The following ASP.Net code gets run when I click on my "Export to Excel" button.
    protected void btnExportToExcel_Click(object sender, EventArgs e)
    {
        // It doesn't get much easier than this...
        CreateExcelFile.CreateExcelDocument(listOfEmployees, "Employees.xlsx", Response);
    }
