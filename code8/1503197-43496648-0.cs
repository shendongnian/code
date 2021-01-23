    public IEnumerable<string> ReadHeaders(string path)
        {
            using (var reader = new StreamReader(path))
            {
                var csv = new CsvReader(reader);
                if (csv.Read())
                    return csv.FieldHeaders;
            }
            return null;
        }
