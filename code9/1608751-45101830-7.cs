    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int studentid = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
            CheckBoxList subjects = (CheckBoxList)GridView1.Rows[e.RowIndex].FindControl("CheckBoxList1");
            List<string> studentsubjects = new List<string>();
            string sublist = "";
            foreach (ListItem item in subjects.Items)
            {
                if (item.Selected)
                {
                    studentsubjects.Add(item.Text);
                }
            }
            if (subjects.Items.Count > 1)
            {
                sublist = string.Join(",", studentsubjects); // add , inside subjects names
            }
            else
            {
                sublist = subjects.SelectedItem.Text;
            }
            SqlConnection conn = new SqlConnection("Data Source=WINCTRL-0938L38; Database=dbUni; Integrated Security=true");
            conn.Open();
            SqlCommand cmd = new SqlCommand("StudentUpdate", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@student_id ", studentid);
            cmd.Parameters.AddWithValue("@subjects ", sublist);
            cmd.ExecuteNonQuery();
            GridView1.EditIndex = -1;
            FillGrid();
            conn.Close();
        }
