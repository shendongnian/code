    public IActionResult ExportData()
    {
        using (var excel = new ExcelPackage())
        {
            var wks = excel.Workbook.Worksheets.Add("StudentReportCard");
            wks.Cells[1,1].LoadFromCollection(GetStudentRecords(), PrintHeaders:true);
            return File(excel.GetAsByteArray(),"application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "export.xlsx");
        };
    }
    private static IEnumerable<StudentRecord> GetStudentRecords()
    {
        yield return new StudentRecord
        {
            Id = 1,
            Name = "John",
            Subject = "Maths",
            Score = 77.9
        };
        yield return new StudentRecord
        {
            Id = 2,
            Name = "Jane",
            Subject = "Maths",
            Score = 78.9
        };
        yield return new StudentRecord
        {
            Id = 3,
            Name = "Jo",
            Subject = "Maths",
            Score = 99.9
        };
    }
