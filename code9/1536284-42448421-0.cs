     if (rs != null)
                {
                    if (dr.Field<string>("Code") == rs.GetDirectoryEntry().Properties["description"].Value.ToString())
                    {
                        if (rs.GetDirectoryEntry().Properties["mail"].Value == null)
                        {
                            MessageBox.Show("This email is N/A.");
                        }
                        else
                        {
                            MessageBox.Show("This users email address is: " + rs.GetDirectoryEntry().Properties["mail"].Value.ToString());
                        }
                    }
                }
