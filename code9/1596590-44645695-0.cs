      var xmlContent = "YOUR XML";
      var xmlDoc = XDocument.Parse(xmlContent);
      var realTeamName = "RealMadrid";
      var realTeam = from team in xmlDoc.Elements("teams")
                                        .Descendants("team")
                     where team.Element("name").Value == realTeamName
                     select team;
      var players = realTeam.Elements("players").Elements(); // get players
      foreach (var player in players)                        // iterate over players
      {
        Console.WriteLine("First name: " + player.Element("firstname").Value);
        Console.WriteLine("Last name: " + player.Element("lastname").Value);
      }
