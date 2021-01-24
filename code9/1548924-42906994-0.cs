    private void button1_Click(object sender, EventArgs e)
            {
                //connect with database
                OleDbConnection connection = new OleDbConnection();
                connection.ConnectionString = @"Provider=""Microsoft.Jet.OLEDB.4.0"";Data Source=""demo.mdb"";User Id=;Password=";
                OleDbCommand command = new OleDbCommand();
                command.CommandText = "select * from parts where Cost<1000 and ListPrice>500";
                DataSet dataSet = new System.Data.DataSet();
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(command.CommandText, connection);
                dataAdapter.Fill(dataSet);
                DataTable dt = dataSet.Tables[0];
                this.dataGridView1.DataSource = dt;
                //export specific data to Excel
                Workbook book = new Workbook();
                Worksheet sheet = book.Worksheets[0];
                book.Worksheets[0].InsertDataTable(this.dataGridView1.DataSource as DataTable, true, 1, 1);
                book.SaveToFile("sample.xlsx", ExcelVersion.Version2010);
                System.Diagnostics.Process.Start("sample.xlsx");
            }
