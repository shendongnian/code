    private static void ReadExcel()
        {
                DataSet ds = new DataSet();
                OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;" +
                "Data Source=Z:\\Codes\\Test1.xls;" +
                "Extended Properties=Excel 8.0;");
                var excelApp = new Microsoft.Office.Interop.Excel.Application();
                OleDbDataAdapter da = new OleDbDataAdapter("Select LTRIM(RTRIM([Col 1])) AS [Col 1],LTRIM(RTRIM([Col 2])) AS [Col 2] From [Plan1$]", conn);
                da.Fill(ds);
               // vGrade.DataSource = ds.Tables[0];
                conn.Close();
        }
