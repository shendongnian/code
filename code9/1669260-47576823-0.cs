    public void LoadChecklist(Object sender, EventArgs e)
    {
        var SearchResultsTable = new DataTable();
        using (var con = new SqlConnection("<ConnectionStringGoesHere>"))
        {
            using (var cmd = new SqlCommand("sp_get_QUADRA_CHECKLIST", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                using(var adapter = new SqlDataAdapter(cmd))
                {
                    using(var dtSIPA = new DataTable())
                    {
                        dtSIPA.Columns.Add("Id", typeof(int)); -- assuming you are looking for a list of int values
                        int[] yourSelectedIndexes = ddlSIPA.GetSelectedIndices();
                        for (int i = yourSelectedIndexes.Length - 1; i >= 0; i--)
                        {
                            dtSIPA.Rows.Add(ddlSIPA.Items[yourSelectedIndexes[i]].Value);
                        }
                        cmd.Parameters.Add("@AP_DEV", SqlDbType.Bit).Value = CbAPDev.Checked;
                        cmd.Parameters.Add("@PROD_DEV", SqlDbType.Bit).Value = cbProdDev.Checked;
                        cmd.Parameters.Add("@ROTYPE", SqlDbType.NVarChar, 255).Value = ddlROTYPE.SelectedItem.Value;
                        cmd.Parameters.Add("@SIPA", SqlDbType.Structured).Value = dtSIPA;
                    }
                    try
                    {
                        adapter.Fill(SearchResultsTable);
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        Response.Write(ex);
                    }                    
                }
            }
        }
     }
