            private void btnSave_Click(object sender, EventArgs e)
            {
                try
                {
                    SqlConnection con = new SqlConnection("Server =.;Database=People; Integrated Security = true");
                    con.Open();
                    SqlCommand cmd = new SqlCommand(); // you can define commandText and connection in SqlCommand(defineArea);
                    cmd.Connection = con;              // like; cmd = newSqlCommand("Insert into...",con);
                    string name = txtName.Text;
                    string gender = txtGender.Text;
                    cmd.CommandText = "Insert into Person(Name,Gender)values('" + name + "','" + gender + "')";
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    con.Close();
    
                    lstBxPerson.Items.Add(name + " - " + gender);
                    MessageBox.Show("Save Success!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Exception : "+ex);
                }
            }
