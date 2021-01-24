     private void btnSrcDataID_Click(object sender, EventArgs e)
            {
                try
                {
                    dgvInsertInfo.Refresh();
                    SqlComm = new SqlCommand();
                    SqlComm.Connection = SqlConn;
                    SqlComm.CommandText = "SELECT * FROM MyDataTable WHERE (DataID LIKE @SDataID)";
                    SqlComm.Parameters.AddWithValue("@SDataID", txtSrcDataID.Text);
                    SqlDataTable = new DataTable();
                    SqlAdapt = new SqlDataAdapter(SqlComm);
                    SqlAdapt.Fill(SqlDataTable);
                                        
                    dgvInsertInfo.DataSource = SqlDataTable;
               
                }
                 catch (Exception ex)
                {
                        MessageBox.Show(ex.Message);
                }
            }
