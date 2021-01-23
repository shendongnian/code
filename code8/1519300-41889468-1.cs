    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            chkboxlsthobbies.ClearSelection();
            //Get the ID
            int id = Int32.Parse(GridView1.DataKeys[Int32.Parse(e.NewEditIndex.ToString())].Values["ID"].ToString());
            SqlCommand cmd = new SqlCommand("select * from CheckboxTable where ID = '"+id+"'", con);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            // Get the exact column and save it in a string.
            string str = dt.Rows[0]["Hobbies"].ToString();
            string[] strlist = str.Split(',').Select(t => t.Trim()).ToArray(); //Split into array and trim it.
            //Finally the main functionality to check the values in checkbox list.
            foreach (string s in strlist)
            {
                foreach (ListItem item in chkboxlsthobbies.Items)
                {
                    if (item.Value == s)
                    {
                        item.Selected = true;
                        break;
                    }
                    
                }
                
            }
