    class Program
    {
        static void Main(string[] args)
        {
            string folderPath = Path.GetDirectoryName(typeof(Program).Assembly.Location);
            string templatePath = Path.Combine(folderPath, "Template.xlsx");
            string filePath = Path.Combine(folderPath, "Export.xlsx");
            if (File.Exists(filePath)) File.Delete(filePath);
            File.Copy(templatePath, filePath);
            using (var ep = new ExcelPackage(new FileInfo(filePath)))
            {
                var ws = ep.Workbook.Worksheets["Families-Types"];
                ws.Cells[3, 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(150, 245, 125));
                ws.Cells[3, 1].Style.Fill.BackgroundColor.Tint = 0;
                ep.Save();
            }
        }
    }
