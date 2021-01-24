        public FileStreamResult ExportToExcel(DataSet ds)
        {           
            using (XLWorkbook wb = new XLWorkbook())
            {
                foreach (DataTable dt in ds.Tables)
                {
                    //Add DataTable as Worksheet.
                    wb.Worksheets.Add(dt);
                }
                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    wb.SaveAs(MyMemoryStream);
                    return FileStreamResult(MyMemoryStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
                }
            }
        }
