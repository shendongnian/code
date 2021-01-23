        public void data3()
        {
            DateTime dt = DateTime.Now;
            DateTime.TryParseExact(datepicker.Text, "mmddyyyy", provider, style out dt);
            int i = Int32.Parse(TextBox1.Text);
                        //DropDownList Binded from database values in another method
            
            using (SqlConnection conn = GetConnString())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    //    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.CommandText = "[dbo].[Table_Update]";
                    cmd.CommandText = "Update Account Table SET SeqNum = SeqNum + @SeqNum, SeqDate = @SeqDate WHERE AccountID = @AccountID";
                    cmd.Parameters.AddWithValue("@SeqNum", TextBox1.Text);
                    cmd.Parameters.AddWithValue("@SeqDate", DateTime.Now);
                    cmd.Parameters["@Account_ID", CheckBoxList1.SelectedValue);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }
