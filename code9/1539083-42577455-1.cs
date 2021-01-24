     private void Submit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure these details are correct?", "Are you sure?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                    dataGridView1.AllowUserToAddRows = false; //Disables edit so the insert doesnt try and do an insert for the blank row created when the user clicks to add data.
                    #region SQL Insert
                    SqlConnection con = new SqlConnection(Home.ConString);
                    SqlCommand cmd = new SqlCommand("EquipmentReturnSubmission1", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    #region Parameters
                    cmd.Parameters.Add("@Name", SqlDbType.VarChar, 200).Value = OfficerName.Text;
                    cmd.Parameters.Add("@Area", SqlDbType.VarChar, 200).Value = Area.Text;
                    cmd.Parameters.Add("@SubmissionDate", SqlDbType.Date).Value = SubmissionDate.Value;
                    cmd.Parameters.Add("@SubmissionID", SqlDbType.Int).Direction = ParameterDirection.Output;
                    
                    #endregion
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (System.Exception ex1)
                    {
                        throw new System.Exception("Error submitting equipment return sheet." + ex1.Message);
                    }
                    finally
                    {
                        SubID = int.Parse(Convert.ToString(cmd.Parameters["@SubmissionID"].Value));
                        con.Close();
                        SecondInsert();
                    }
                    #endregion
                }
            }
        }
        private void SecondInsert()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                
                SqlConnection con = new SqlConnection(Home.ConString);
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO EquipmentReturnSubmissionDetails (SubmissionID, SerialNumber, Description) VALUES (@SubmissionID, @SerialNumber, @Description)", con);
                    cmd.CommandType = CommandType.Text;
                    {
                        cmd.Parameters.AddWithValue("@SubmissionID", SqlDbType.Int).Value = SubID;
                        cmd.Parameters.AddWithValue("@SerialNumber", row.Cells["SerialNo"].Value);
                        cmd.Parameters.AddWithValue("@Description", row.Cells["Description"].Value);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                
            }
            MessageBox.Show("Data submitted.");
            this.Close();
        }
