        [WebMethod]
        public string dictToExcel(string dict_name)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["OracleConnection"].ConnectionString;
            OracleConnection connection = new OracleConnection(connectionString);
            try
            {
                connection.Open();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = connection;
                cmd.CommandText = "SELECT * from " + dict_name;
                cmd.CommandType = CommandType.Text;
                OracleDataReader dataReader = cmd.ExecuteReader();
                
                IWorkbook workbook;
                workbook = new XSSFWorkbook();
                ISheet sheet = workbook.CreateSheet("Sheet 1");
                int b = 0;
                while (dataReader.Read())
                {
                    int n = 0;
                    IRow row = sheet.CreateRow(b);
                    while (n < dataReader.FieldCount)
                    {
                        ICell cell = row.CreateCell(n);
                        String columnName = dataReader.GetValue(n).ToString();
                        cell.SetCellValue(columnName);
                        n++;
                    }
                    b++;
                }
