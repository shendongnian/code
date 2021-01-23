    using (SqlConnection con = new SqlConnection(ConnStr))
                {
                    con.Open();
    
                    String SQL = "SELECT ID, LastName, FirstName, MiddleName, Gender, BirthDate, CivilStatus, " +
                        "Citizenship, MobileNo, Landline, PermanentAddress, Address FROM Residents " +
                        "WHERE FirstName LIKE '%@name%' OR LastName LIKE '%@name%'";
                    var cmd = new SqlCommand(SQL, connection);
                    cmd.Parameters.Add("@name", SqlDbType.Text);
                    cmd.Parameters["@name"].Value = name;
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        dt.Load(sdr);
                    }
                }
