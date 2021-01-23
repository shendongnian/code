    DateTime dt = DateTime.Now;
            DateTime.TryParseExact(datepicker.Text, "mmddyyyy", provider, style out dt);
            int i = Int32.Parse(TextBox1.Text);
            //DropDownList Binded from database values in another method
            
                            using (SqlConnection = GetConnString()){
                    conn.Open();
                    foreach (ListItem item in CheckBoxList.Items)
            {
                    using (SqlCommand cmd = new SqlCommand() {
                    //    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.CommandText = "[dbo].[Table_Update]";
                    cmd.CommandText = "Update Account Table SET SeqNum = SeqNum + @SeqNum, SeqDate = @SeqDate WHERE AccountID = @AccountID";
                    if (item.Selected)
                    {
                        cmd.Parameters.AddWithValue("@SeqNum", i);
                        cmd.Parameters.AddWithValue("@SeqDate", DateTime.Now);
                        cmd.Parameters["@Account_ID", CheckBoxList1.SelectedValue);
                        cmd.ExecuteNonQuery();
                      }
                    }
                    conn.Close();
                }
 
