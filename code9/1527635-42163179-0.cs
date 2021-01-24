    string vonDatum = dtpVon.Value.ToString("dd.MM.yyyy");
            DateTime startDatum = DateTime.ParseExact(vonDatum, "dd.MM.yyyy", null);
            string bisDatum = dptBis.Value.ToString("dd.MM.yyyy");
            DateTime endDatum = DateTime.ParseExact(bisDatum, "dd.MM.yyyy", null);
     for (DateTime date = startDatum; date <= endDatum; date = date.AddDays(1))
                {
                    string datum = String.Format("{0:dd/MM/yyyy}", date);
                    // Erste tabellenbefüllung erstellen 
                    sqlite_cmd.CommandText = "INSERT INTO einteilung (mitarbeiter, arbeitsschicht, datum) VALUES ('"+mitarbeiter+"', '"+arbeitsschicht+"', '"+datum +"');";
                    sqlite_cmd.ExecuteNonQuery();
                }
