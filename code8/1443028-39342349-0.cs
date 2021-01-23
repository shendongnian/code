    try
                {
                using (Hawthor_HS_Entities db = new Hawthor_HS_Entities())
                {
                    Administrator addAdministrator = new Administrator();// currently adding only the AID and nothing else.
                    {
                        addAdministrator.FName = txtAdminFname.Text;
                        addAdministrator.LName = txtAdminLname.Text;
                        addAdministrator.Password = txtNewPass.Text;
                    }
                        db.Administrators.Add(addAdministrator);
                        db.SaveChanges();
                        DataGridLoad();
                        int Id = addAdministrator.ID; // you can able to get the id for the record you attempt to save.
                        MessageBox.Show("Success! New Administrator was Added");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error: Could not Add new Administrator. Please try again.");
                }
