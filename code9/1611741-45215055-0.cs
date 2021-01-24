            using (SqlConnection sqlcn1 = new SqlConnection("My Server Connection String"))
            {
                sqlcn1.Open();
                //Stored Procedure
                using (SqlCommand sqlcmddel = new SqlCommand("My_Stored_Procedure", sqlcn1))
                {
                    sqlcmddel.CommandType = CommandType.StoredProcedure;
                    sqlcmddel.ExecuteNonQuery();
                }
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    using (SqlCommand sqlcmdins = new SqlCommand("My_Stored_Procedure", sqlcn1))
                    {
                        sqlcmdins.CommandType = CommandType.StoredProcedure;
                            //Stored Procedure
                        sqlcmdins.Parameters.Add("@sugnum", SqlDbType.Int).Value = row.Cells[0].Value;
                        sqlcmdins.Parameters.Add("@sugtype", SqlDbType.NVarChar, 50).Value = row.Cells[1].Value;
                        sqlcmdins.Parameters.Add("@buyerid", SqlDbType.NVarChar, 50).Value = row.Cells[2].Value;
                        sqlcmdins.Parameters.Add("@duedate", SqlDbType.DateTime).Value = row.Cells[3].Value;
                        sqlcmdins.Parameters.Add("@xrelqty", SqlDbType.Float).Value = row.Cells[4].Value;
                        sqlcmdins.Parameters.Add("@purchasingfactor", SqlDbType.Float).Value = row.Cells[5].Value;
                        sqlcmdins.Parameters.Add("@relqty", SqlDbType.Float).Value = row.Cells[6].Value;
                        sqlcmdins.Parameters.Add("@jobnum", SqlDbType.NVarChar, 20).Value = row.Cells[7].Value;
                        sqlcmdins.Parameters.Add("@assemblyseq", SqlDbType.SmallInt).Value = row.Cells[8].Value;
                        sqlcmdins.Parameters.Add("@jobseq", SqlDbType.SmallInt).Value = row.Cells[9].Value;
                        sqlcmdins.Parameters.Add("@warehousecode", SqlDbType.NVarChar, 50).Value = row.Cells[10].Value;
                        sqlcmdins.Parameters.Add("@fob", SqlDbType.NVarChar, 50).Value = row.Cells[11].Value;
                        sqlcmdins.Parameters.Add("@shipviacode", SqlDbType.NVarChar, 50).Value = row.Cells[12].Value;
                        sqlcmdins.Parameters.Add("@termscode", SqlDbType.NVarChar, 50).Value = row.Cells[13].Value;
                        sqlcmdins.Parameters.Add("@vendornum", SqlDbType.Int).Value = row.Cells[14].Value;
                        sqlcmdins.Parameters.Add("@purpoint", SqlDbType.Int).Value = row.Cells[15].Value;
                        sqlcmdins.Parameters.Add("@linedesc", SqlDbType.NVarChar, 50).Value = row.Cells[16].Value;
                        sqlcmdins.Parameters.Add("@ium", SqlDbType.NVarChar, 10).Value = row.Cells[17].Value;
                        sqlcmdins.Parameters.Add("@unitprice", SqlDbType.Float).Value = row.Cells[18].Value;
                        sqlcmdins.Parameters.Add("@docunitprice", SqlDbType.Float).Value = row.Cells[19].Value;
                        sqlcmdins.Parameters.Add("@taxable", SqlDbType.Bit).Value = row.Cells[20].Value;
                        sqlcmdins.ExecuteNonQuery();
                    }
                }
            }
