        private void updatebutton_Click()
        {
            using (OleDbConnection con = new OleDbConnection("Define your Connection String here"))
            {
                string query = @"UPDATE Emplyeedata
                            SET [id] = @ID
                               ,[Name] = @Name
                               ,[Deisgnation] = @Deisgnation
                               ,[Leave] = @Leave
                            WHERE [Name] = @Name";
                using (OleDbCommand cmd = new OleDbCommand(query, con) { CommandType = CommandType.Text })
                {
                    cmd.Parameters.AddWithValue("@ID", midbox.Text);
                    cmd.Parameters.AddWithValue("@Name", mnamebox.Text);
                    cmd.Parameters.AddWithValue("@Deisgnation", mdesbox.Text);
                    cmd.Parameters.AddWithValue("@Leave", mleavebox.Text);
                    cmd.Parameters.AddWithValue("@Name", mnamebox.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }
