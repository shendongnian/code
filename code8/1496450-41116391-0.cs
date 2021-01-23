    using (var connection = new SqlConnection(connectionString))
     {
        using (var cmd = connection.CreateCommand())
         {
            var selected_item = lstCountry.SelectedItem.ToString();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT ModuleMaster (ModuleName, Country, ModuleLeader, FirstAml, SecondAml, CoreTeamMember) "
                           + $"SELECT ModuleName, Country, ModuleLeader, FirstAml, SecondAml, CoreTeamMember FROM CountryMaster WHERE CountryName = {selected_item}";
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
         }
     }
