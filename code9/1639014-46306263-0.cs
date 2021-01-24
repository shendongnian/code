    foreach (DataRow dr in result.Tables[0].Rows)
            {
                Excel addTable = new Excel()
                {
                   
                    ime = Convert.ToString(dr[1])
                };
                //   conn.ExecuteCommand("TRUNCATE TABLE Excel");
                conn.ExecuteCommand("DELETE FROM Excel where ime='a'");
                conn.Excels.InsertOnSubmit(addTable);
            }
