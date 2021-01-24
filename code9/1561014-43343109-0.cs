        static void Main(string[] args)
        {
                // Create Connection to Excel Workbook
                using (OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source='D:\Practice.xlsx';Extended Properties='Excel 8.0;HDR=Yes;'"))
                {
                    OleDbCommand command = new OleDbCommand("Select * FROM [Sheet1$]", connection);
                    connection.Open();
                    // Create DbDataReader to Data Worksheet
                    using (OleDbDataReader dr = command.ExecuteReader())
                    {
                        Console.WriteLine(dr.GetString(0) + "\t" + dr.GetString(1) + "\t" + dr.GetString(2));
                    }
                }
            Console.ReadKey();
        }
