     var idsNotInB = dtLotsInst.AsEnumerable().Select(r => r.Field<int>("institutionid"))
        .Except(dtWebbitInst.AsEnumerable().Select(r => r.Field<int>("institutionid")));
             count = idsNotInB.Count();
            if (count != 0)
            {
                DataTable dtOnlyLots = (from row in dtLotsInst.AsEnumerable()
                                        join id in idsNotInB
                                        on row.Field<int>("institutionid") equals id
                                        select row).CopyToDataTable();
                using (OleDbConnection con = new OleDbConnection(PackChecker.Properties.Settings.Default["WebbitConnectionString"].ToString()))
                {
                    string strgetloc = @"INSERT INTO tblinstitution ( dispenseinstid, institutionname ) VALUES (?,?)";
                    using (OleDbCommand cmd = new OleDbCommand(strgetloc, con))
                    {
                        con.Open();
                        foreach (DataRow dr in dtOnlyLots.Rows)
                        {
                            cmd.Parameters.Add("?", OleDbType.Integer).Value = Convert.ToInt32(dr["institutionid"]);
                            cmd.Parameters.Add("?", OleDbType.VarWChar).Value = dr["institutionname"].ToString();
                            cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                        }
                        con.Close();
                    }
                }
            }
