    User userAdmin = (from admin in dbATMT.UserSet.OfType<Administrator>()
    where admin.Username.Equals(username) select admin).FirstOrDefault();
    
                            if (userAdmin == null || !admin.Password.Equals(password))
                            {
                                MessageBox.Show("Invalid");
                            }
                            else
                            {
                                //logs in
                            }
