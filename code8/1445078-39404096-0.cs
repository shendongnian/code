     protected DataTable SearchResident(String name, String ConnStr)
        {           
            try
            {
                String SQL = "SELECT ID, LastName, FirstName, MiddleName, Gender, BirthDate, CivilStatus, " +
                        "Citizenship, MobileNo, Landline, PermanentAddress, Address FROM Residents " +
                        "WHERE FirstName LIKE '%name%' OR LastName LIKE '%name%'";
                using (SqlConnection sqlConn = new SqlConnection(ConnStr))
                using (SqlCommand cmd = new SqlCommand(SQL, sqlConn))
                {
                    sqlConn.Open();
                    DataTable dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());
                    return  dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
