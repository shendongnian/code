    using (SqlConnection connection = new SqlConnection(_connectionString))
    {
        string query = @"SELECT * FROM Adopters;
                         SELECT * FROM States;
                         SELECT * FROM Pets;
                         SELECT * FROM Status;
                         SELECT * FROM Genders;";
        using (var multi = connection.QueryMultiple(query, null))
        {
            var adopters = multi.Read<Adopter>();
            var states = multi.Read<State>();
            var pets = multi.Read<Pet>();
            var statuses = multi.Read<Status>();
            var genders = multi.Read<Gender>();
            foreach (Adopter adp in adopters)
            {
                adp.State = states.FirstOrDefault(x => x.Id == adp.StateID);
                adp.Pets = pets.Where(x => x.IsAdopted && 
                                      x.AdopterID.HasValue && 
                                      x.AdopterID.Value == adp.AdopterID)
                                      .ToList();
                foreach(Pet pet in adp.Pets)
                {
                    pet.Status = statuses.FirstOrDefault(x => x.Id == pet.StatusID);
                    pet.Gender = genders.FirstOrDefault(x => x.Id == pet.GenderID);
                }
            }
        }
    }
