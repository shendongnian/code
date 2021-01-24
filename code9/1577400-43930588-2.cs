            if (Directory.Exists(FileNamePath))
            {
                List<string> dbFileNames = null;
                string qry = "select FileName from MembersFiles where fk_MemberId='" + GlobalValues.Member_PkId + "' and Document_Type='" + doc + "'";
                using (SqlDataAdapter da = new SqlDataAdapter(qry, con))
                {
                    con.Open();
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dbFileName = dt.Rows.OfType<DataRow>()
                        .Select(r => r[0].ToString()).ToList();
                    con.Close();
                }
                string[] fileNames1 = dbFileNames.Select(f =>
                Path.Combine(FileNamePath, f)).ToArray();
            }
