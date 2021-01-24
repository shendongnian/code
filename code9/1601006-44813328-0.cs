    public void AddUitslag(Uitslag uitslag)
     {
       using (SqlConnection connection = Database.Connection)
       {
            VerkiezingRepository VerkiezingRepo = new VerkiezingRepository(new SQLVerkiezingContext());
            foreach (Partij p in uitslag.DeelnemendePartijen)
            {
                string query = "Insert into Uitslag(Naam, Datum, Verkiezing_ID, Partij_ID) values (@Naam, @Datum, @Verkiezing, @Partij_ID)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Naam", uitslag.Naam);
                    command.Parameters.AddWithValue("@Datum", uitslag.Datum);
                    command.Parameters.AddWithValue("@Verkiezing",  VerkiezingRepo.GetVerkiezing(uitslag.Verkiezing.Naam).ID);
                    command.Parameters.AddWithValue("@Partij_ID", p.Afkorting);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
