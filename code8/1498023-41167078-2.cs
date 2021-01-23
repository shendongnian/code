    int autonr = 0;
    if (!int.TryParse(autonrTextBox.Text, autonr))
    {
        MessageBox.Show("Waarschuwing u kunt geen auto verwijderen indien er GEEN autonr is ingevuld");
    }
    else
    {
        try 
        {
            using (var con = new SqlConnection(@"Data Source=DESKTOP-RSEBNR7;Initial Catalog=AudiDealer;Integrated Security=True"))
            using (var cmd = new SqlCommand("DELETE FROM auto WHERE autonr = @autonr;", con))
            {
                cmd.Parameters.Add("@autonr", SqlDbType.Int).Value = autonr;
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result <= 0)
                {
                     MessageBox.Show("Het opgegeven autonr komt niet voor in de database. controleer deze.");
                }
            }
            catch (SystemException ex)
            {
                MessageBox.Show(string.Format("An error occurred: {0}", ex.Message));
            }
        }
    }
