    public static void ComboBoxFill(ComboBox cbo, string Query, string cboDisplayMember, string cboValueMember)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(Query, con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    cbo.DataSource = dt;
                    DataRow newRow = dt.NewRow();
                    newRow[0] = "Select";
                    dt.Rows.InsertAt(newRow, 0);
 
                    cbo.DisplayMember = cboDisplayMember;
                    cbo.ValueMember = cboValueMember;
                    cbo.SelectedIndex = 0;
                    con.Close();
                }
