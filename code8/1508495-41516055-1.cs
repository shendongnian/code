    public class Gebruikerklasse 
    {
        ....
        public bool Exists()
        {
            string commandText = @"Select count (*) from Gebruiker 
                                  where Wachtwoord = @Wachtwoord AND 
                                 Gebruikersnaam = @Gebruikersnaam;", 
            using (SqlConnection conn = new SqlConnection(DBClass.GetConnectionString()))
            using (SqlCommand cmd = new SqlCommand(commandText, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@Gebruikersnaam", gebruiker.Gebruikersnaam);
                cmd.Parameters.AddWithValue("@Wachtwoord", gebruiker.Wachtwoord);
                int a = Convert.ToInt32(cmd.ExecuteScalar());
                return (a > 0);
            }
        }
    }
