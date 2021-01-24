    string jsonText = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "test.json");
            using (StreamReader r = new StreamReader(jsonText))
            {
                string json = r.ReadToEnd();
                dynamic dynamicJson = JsonConvert.DeserializeObject(json);
                foreach (var item in dynamicJson)
                {
                    if (item.Name == "db_table_name")
                        Console.WriteLine(item.Value);
                    if (item.Name == "Date of Audit")
                        Console.WriteLine(item.Value);
                }
            }
