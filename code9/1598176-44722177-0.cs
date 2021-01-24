    private void Section3_Load(object sender, EventArgs e)
            { 
                SqlConnection conn = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("select Id, name from SWApp_List_Equipment WHERE type = 'referral or signposting' ORDER BY order_no,name", conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
    
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        referral.Add(dr["id"].ToString(), dr["name"].ToString());
                    }
                }
    
                foreach (KeyValuePair<string, string> refs in referral)
                {
                    box = new CheckBox();
                    box.Text = refs.Value.ToString();
                    actionsTakenCheckBoxList.Items.Add(box.Text);
                    box.CheckedChanged += new EventHandler(this.CheckedChange);
                } 
            }
