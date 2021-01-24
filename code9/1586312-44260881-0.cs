    var assembly = Assembly.GetExecutingAssembly();
    const string country = "Service.Migrations.Seed.countries.csv";
                using (var stream = assembly.GetManifestResourceStream(country))
                {
                    using (var reader = new StreamReader(stream, Encoding.UTF8))
                    {
                        var csvReader = new CsvReader(reader);
                        csvReader.Configuration.Delimiter = ",";
                        csvReader.Configuration.WillThrowOnMissingField = false;
                        var countries = csvReader.GetRecords<Country>().ToArray();
                        foreach (var c in countries)
                        {
                            var check = context.Countries.FirstOrDefault(p => p.Name == c.Name);
                            if (check == null)
                            {
                                context.Countries.Add(c);
                                context.SaveChanges();
                            }
                        }
                    }
                }
