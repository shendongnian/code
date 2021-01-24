    var dbFile = "stats.db";
    var statList = new List<Statistics>();
    var sqlBase = new SQLiteConnection(dbFile);
    sqlBase.Execute("PRAGMA foreign_keys = ON");
    sqlBase.CreateTable<Domains>();
    sqlBase.CreateTable<Statistics>();
    // Fetch existing domains from database
    var domains = sqlBase.Table<Domains>().toList();
    
    if (domains.isEmpty()) {
        // Insert domains into database if they don't exist
        var domainNames = new[] { "stackoverflow.com", "superuser.com", "serverfault.com", "google.com", "microsoft.com" };
        domains = domainNames.Select(domainName => new Domain(domainName));
        sqlBase.InsertAll(domains);
    }
    var runTimestamp = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
    foreach (var domain in domains)
    {
        HttpWebResponse resp = null;
        var status = -1;
        try
        {
            resp = (HttpWebResponse)WebRequest.Create("http://" + domain.domain).GetResponse();
        }
        catch { };
        status = (int)resp.StatusCode;
        var stat = new Statistics();
        stat.Domain = domain; // Assign the existing domain object
        stat.Status = status;
        stat.Timestamp = runTimestamp;
        statList.Add(stat);
    }
    // Insert only Statistics (Domains already exist), and assign foreign keys
    sqlBase.InsertAllWithChildren(statList);
