                foreach (var rec in DataConnection.Query<dynamic>(reader =>
                {
                    IDictionary<string, object> eo = new ExpandoObject();
                    for (var index = 0; index < reader.FieldCount; index++)
                    {
                        eo.Add(reader.GetName(index), reader.GetValue(index));
                    }
                    return eo;
                }, "select first 2 \"Guid\", \"DongleID\" from \"Sellings\""))
                {
                    Console.WriteLine(rec.DongleID);
                }
