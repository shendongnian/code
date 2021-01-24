     string ConString = "sale.db";
     string passedquery = "select * from Events";
            DataTable dt = new DataTable();
            using (SQLiteConnection con = new SQLiteConnection(ConString))
            {
                try
                {
                    using (var statement = con.Prepare(passedquery))
                    {
                        for (int i = 0; i < statement.ColumnCount; i++)
                        {
                            dt.Columns.Add(statement.ColumnName(i));
                        }
                        while (statement.Step() == SQLiteResult.ROW)
                        {
 
                            DataRow dr;
                            dr = dt.NewRow();
 
                            for (int i = 0; i < statement.ColumnCount; i++)
                            {
                                dr[i] = statement[i];
                            }
                            dt.Rows.Add(dr);
                        }
                    }
                }
 
                catch(SQLitePCL.SQLiteException)
                {
 
                    MessageBox.Show("Nieprawidłowe zapytanie");
                }             
            }
            dtgCustomReport.DataContext = dt.DefaultView;
