    var allValues = File.ReadAllLines(@"C:\Users\adamoui\Desktop\Statjbm_20161009.txt")
        .Select(x => x.Split(new char[] { '|' }, 2)[0])
        .ToArray();
    var yesterday = DateTime.Now.AddDays(-1);
    con.Insert(Range(0, allValues.Length, 4).Select(x => {
        return new {
            Noeud = "JBM",
            Delivered = allValues[x + 0],
            Expired = allValues[x + 1],
            Undeliverable = allValues[x + 2],
            Total_Mt = allValeus[x + 3],
            Date = yesterday
        };
    }));
