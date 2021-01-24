      using (var con = new SqlConnection(@"Data Source=NT;Initial Catalog=StudentDB;Integrated Security=True"))
            {
                con.Open();
                var excelFile = new FileInfo(@"TestFile.xlsx");
                using (var epPackage = new ExcelPackage(excelFile))
                {
                    var worksheet = epPackage.Workbook.Worksheets.First();
                    for (var row = 1; row <= worksheet.Dimension.End.Row; row++)
                    {
                        var rowValues = worksheet.Cells[row, 1, row, worksheet.Dimension.End.Column];
                        var cmd = new SqlCommand("INSERT INTO Persons(ContactID, FirstName, SecondName, Age) VALUES (@contactid, @firstname, @secondname, @age)", con);
                        cmd.Parameters.AddWithValue("@contactid", rowValues["A1"].Value);
                        cmd.Parameters.AddWithValue("@firstname", rowValues["B1"].Value);
                        cmd.Parameters.AddWithValue("@secondname", rowValues["C1"].Value);
                        cmd.Parameters.AddWithValue("@age", rowValues["D1"].Value);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
