    foreach (DataGridViewRow dgRow in dgw.Rows)
            {
                string name = dgRow.Cells[1].Value.ToString();
                con.Close();
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "select price from  invo where main='"+name+"' '";
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    if (rdr.IsDBNull(0))
                    {
                    }
                    else
                    {
                        dgRow.Cells[5].Value = (rdr.GetDecimal(0).ToString());
                        break; //return; Get you out of the function, additional 
                               //rows are not evaluated
                    }
                }
            }
