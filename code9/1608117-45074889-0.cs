    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int studentid = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
            CheckBoxList studentsubjects = (CheckBoxList)GridView1.Rows[e.RowIndex].FindControl("CheckBoxList1");
            SqlConnection conn = new SqlConnection("Data Source=WINCTRL-0938L38; Database=dbUni; Integrated Security=true");
            conn.Open();
            foreach (ListItem item in studentsubjects.Items)
            {
                if (item.Selected) // checks which subjects selected and updates
                {
                    SqlCommand cmd = new SqlCommand("StudentUpdate", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@student_id ", studentid);
                    cmd.Parameters.AddWithValue("@subjects ", item.Text);
                    cmd.ExecuteNonQuery();
                }
            }
            GridView1.EditIndex = -1;
            FillGrid();
            conn.Close();
        }
