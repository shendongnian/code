    DateTime dt = DateTime.Now;
            DateTime.TryParseExact(datepicker.Text, "mmddyyyy", provider, style out dt);
            int i = Int32.Parse(TextBox1.Text);
            //DropDownList Binded from database values in another method
            
            foreach (ListItem item in CheckBoxList.Items)
            {
                using (SqlConnection = new SqlConnection (GetConnString())){
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand() {
                        cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[dbo].[Table_Update]";
                    if (item.Selected)
                    {
                        cmd.Parameters.AddWithValue("@SeqNum", i);
                        cmd.Parameters.AddWithValue("@SeqDate", DateTime.Now);
                        cmd.Parameters["@Account_ID", CheckBoxList1.SelectedValue);
                        cmd.ExecuteNonQuery();
                    }
                    SqlConnection.Close();
                }
            }
