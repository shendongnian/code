    static void Main(string[] args)
    {
        var dbFile = "stats.db";
        var domains = new[] { "stackoverflow.com", "superuser.com", "serverfault.com", "google.com", "microsoft.com" };
        var statList = new List<StatisticsView>();
        var sqlBase = new SQLiteConnection(dbFile);
        sqlBase.CreateTable<Domains>();
        sqlBase.CreateTable<Statistics>();
        sqlBase.Execute("CREATE VIEW IF NOT EXISTS 'StatisticsView' AS SELECT Stat.Id, Stat.Timestamp, Dom.Domain, Stat.Status FROM Statistics AS Stat INNER JOIN Domains Dom ON Stat.DomainId=Dom.Id;");
        sqlBase.Execute("CREATE TRIGGER IF NOT EXISTS 'StatisticsViewInsert' INSTEAD OF INSERT ON 'StatisticsView' BEGIN INSERT OR IGNORE INTO Domains(Domain) VALUES(NEW.Domain); INSERT INTO Statistics(Timestamp, Status, DomainId) VALUES (NEW.Timestamp, NEW.Status, (SELECT Id FROM Domains WHERE Domain=NEW.Domain)); END");
        sqlBase.Execute("CREATE TRIGGER IF NOT EXISTS 'StatisticsViewUpdate' INSTEAD OF UPDATE ON 'StatisticsView' BEGIN INSERT OR IGNORE INTO Domains(Domain) VALUES(NEW.Domain); UPDATE Statistics SET Status=NEW.Status, Timestamp=NEW.Timestamp, DomainId=(SELECT Id FROM Domains WHERE Domain=NEW.Domain) WHERE Id=OLD.Id; END");
        sqlBase.Execute("CREATE TRIGGER IF NOT EXISTS 'StatisticsViewDelete' INSTEAD OF DELETE ON 'StatisticsView' BEGIN DELETE FROM Domains WHERE (Domain = OLD.Domain AND (SELECT COUNT(Id) FROM Statistics WHERE DomainId=(SELECT Id FROM Domains WHERE Domain=OLD.Domain)) < 2); DELETE FROM Statistics WHERE Id=OLD.Id; END");
        Console.WriteLine(SQLite3.LibVersionNumber());
        var runTimestamp = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
        foreach (var domain in domains)
        {
            HttpWebResponse resp = null;
            var status = -1;
            try
            {
                resp = (HttpWebResponse)WebRequest.Create("http://" + domain).GetResponse();
            }
            catch { };
            status = (int)resp.StatusCode;
            var stat = new StatisticsView();
            stat.Domain = domain;
            stat.Status = status;
            stat.Timestamp = runTimestamp;
            statList.Add(stat);
        }
        sqlBase.InsertAll(statList);
        Console.WriteLine(@"Table ""Domains""");
        foreach (var table in sqlBase.Table<Domains>())
        {
            Console.WriteLine("Id: {0}\tDomain: {1}", table.Id, table.Domain);
        }
        Console.WriteLine();
        Console.WriteLine(@"Table ""Statistics""");
        foreach (var table in sqlBase.Table<Statistics>())
        {
            Console.WriteLine("Id: {0}\tDomain Id: {1}", table.Id, table.DomainId);
        }
        Console.WriteLine();
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
