    using (var reader = AvroContainer.CreateGenericReader(buffer))
            {
                while (reader.MoveNext())
                {
                    foreach (dynamic record in reader.Current.Objects) {
                          // Take a look at what you get in the record
                    }
                }
            }
