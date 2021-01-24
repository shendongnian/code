    var recList = new List<Record>();
    using (var conn = new MySqlConnection(connString))
    {
        using (var cmd = new MySqlCommand(query, conn))
        {
            conn.Open();
            using (var reader = cmdDatabase.ExecuteReader())
            {
                while (reader.Read())
                { 
                    recList.Add(new Record(reader));
                }
            }
        }
        conn.Close();
    } 
    if (!recList.Any()) // System.Linq
        return;
    IEnumerable<string> textFileRecords = recList.Select(x => x.ToString());
    File.WriteAllLines(pathName, textFileRecords); // System.IO
