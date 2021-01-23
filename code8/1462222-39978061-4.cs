    var allValues = File.ReadAllLines(@"C:\Users\adamoui\Desktop\Statjbm_20161009.txt")
        .Select(x => x.Split(new char[] { '|' }, 2)[0])
        .ToArray();
    var yesterday = DateTime.Now.AddDays(-1);
    var records = Range(0, allValues.Length, 4).Select(x => {
        return new {
            Noeud = "JBM",
            Delivered = allValues[x + 0],
            Expired = allValues[x + 1],
            Undeliverable = allValues[x + 2],
            TotalMt = allValeus[x + 3],
            Date = yesterday
        };
    });
    foreach (var record in records)
    {
        using (var command = new SqlCommand(InsertRecordCommand , con))
        {
            command.Parameters.AddWithValue("@Noeud", record.Noeud);
            command.Parameters.AddWithValue("@DELIVERED", record.Delivered);
            command.Parameters.AddWithValue("@EXPIRED", record.Expired);
            command.Parameters.AddWithValue("@UNDELIVERABLE", record.Undeliverable);
            command.Parameters.AddWithValue("@Total_MT", record.TotalMt);
            command.Parameters.AddWithValue("@Date", record.Date);
    
            command.ExecuteNonQuery();                
        }
    }
