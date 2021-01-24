    var realTeam = from db in xelement.Elements("team")
                   where (string)db.Element("name")=="RealMadrid"
                   select db.Elements("players");
    //Console.WriteLine("Real Madrid");
    foreach (var e in realTeam.Elements())
    {
        Console.WriteLine("First Name: " + e.Element("firstname").Value);  //or e.Element("firstname").ToString()
        Console.WriteLine("Last Name: " + e.Element("lastname").Value);
    }
