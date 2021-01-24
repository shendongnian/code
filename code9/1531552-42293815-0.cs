    using (SqlDataAdapter sda = new SqlDataAdapter())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Country", "KENYATEST");
                cmd.Connection = con;
                sda.SelectCommand = cmd;
                using (dt = new DataTable())
                {
                    sda.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                       allocatedsum += Convert.ToInt32(dr["AllocatedQuantity"]);
                       nominatedsum += Convert.ToInt32(dr["NominatedQuantity"]);
                       volume += Convert.ToDouble(dr["Volume"]);
                      ProvisionalUSD += Convert.ToInt32(dr["ProvisionalUSD"]);
                       ProvisionalKES += Convert.ToInt32(dr["ProvisionalKES"]);
                    }
                    //Create a row for totals over here
                    DataRow totalRow = dt.NewRow();
                    //Then set the total values inside this row
                    totalRow["ColumnName"] = "Column Total"; //for each column
                    dt.Rows.Add(totalRow); //finally add the new row to your dource datatable
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
    } }
