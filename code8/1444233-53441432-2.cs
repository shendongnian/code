    [HttpPost]
    public async Task<FileContentResult> Create([Bind("Id,StartDate,EndDate")] GetReport getReport)
    {
        DateTime startDate = getReport.StartDate;
        DateTime endDate = getReport.EndDate;
        // call the stored procedure and store dataset in a List.
        List<User> users = _context.Reports.FromSql("exec dbo.SP_GetEmpReport @start={0}, @end={1}", startDate, endDate).ToList();
        //set custome column names
        string[] columns = { "Name", "Address", "ZIP", "Gender"};
        byte[] filecontent = ExcelExportHelper.ExportExcel(users, "Users", true, columns);
        // set file name.
        return File(filecontent, ExcelExportHelper.ExcelContentType, "Report.xlsx"); 
    }
