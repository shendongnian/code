                using (SqlConnection conn = new SqlConnection(GetConnectionString()))
                using (SqlDataAdapter ada = new SqlDataAdapter("SELECT BatchCode, BatchCodeDesc FROM BatchTable", conn))
                {
                    try
                    {
                        DataTable batch_codes = new DataTable();
                        ada.Fill(batch_codes);
                        ddlBatchCodeDel.DataSource = batch_codes;
                        ddlBatchCodeDel.DataTextField = "BatchCodeDesc";
                        ddlBatchCodeDel.DataValueField = "BatchCode";
                        ddlBatchCodeDel.DataBind();
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show(ex.Message);
                    }
                }
