    public bool TestConnection(IDbConnection con)
            {
                using (con)
                {
                    try
                    {
                        con.Open();
                        con.Close();
                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
