         public static void ComboBoxFill(ComboBox cbo, string Query, string cboDisplayMember, string cboValueMember)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(Query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            DataRow drow = dt.NewRow();
            for (int i = 0; i < dt.Columns.Count ; i++)
            {
                if (dt.Columns[i].ColumnName == cboDisplayMember)
                {
                    drow[i] = "Select";
                }
                else if (dt.Columns[i].ColumnName == cboValueMember)
                {
                    drow[i] = 0;
                }
                else
                {
                    drow[i] = null;
                }
            }
            dt.Rows.InsertAt(drow, 0);
            cbo.DataSource = dt;
            cbo.DisplayMember = cboDisplayMember;
            cbo.ValueMember = cboValueMember;
            cbo.SelectedIndex = 0;
            con.Close();
        }
