    // Button1 Click
    
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(); // you can define commandText and connection in SqlCommand(defineArea);
                    cmd.Connection = con;              // like; cmd = newSqlCommand("Insert into...",con);
                    string name = "Kadir";
                    string gender = "male";
                    cmd.CommandText = "Insert into Person(Name,Gender)values('" + name + "','" + gender + "')";
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
    
                // After That you can add this value to listbox
    
                Persoon nieuwpersoon = new Persoon(naam, geslacht);
                personen.Add(nieuwpersoon);
    
                foreach (var Persoon in personen)
                {
                    lb_gebruikers.Items.Add("Naam: " + nieuwpersoon.Naam +
                    "Geslacht: " + nieuwpersoon.Geslacht);
                }
