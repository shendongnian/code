    private void BtnDelete_Click(object sender, EventArgs e)
            {
                string TrashedDoc = listBox1.SelectedItem.ToString();
    
                if (MessageBox.Show("Are you sure you want to Delete this File?", "Delete File", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
    
                    string connStr = @"...............";
                    string qryDelete = "DELETE FROM [DocStorage] WHERE DocumentName = @DocShred";
    
                    using (SqlConnection con = new SqlConnection(connStr))
                    using (SqlCommand cmd = new SqlCommand(qryDelete, con))
                    {
                        cmd.Parameters.Add(new SqlParameter("@DocShred", TrashedDoc));
    
                        con.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        con.Close();
                    }
    
                    /// if the Delete is successful a message box confirms to user
    
                    MessageBox.Show("Delete Successful", "File Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
    
                }
    
            }
