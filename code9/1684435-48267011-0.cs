	using System;
	using System.Collections.Generic;
	using System.Linq;
	namespace ConsoleApp1
	{
		class Program
		{
			public class Region
			{
				public string Name;
				// additional data ...
			}
			public class Server
			{
				public string Name;
				public string RegionName;
				// additional data ...
			}
			public class Player
			{
				public string Name;
				public int Scores;
				public string ServerName;
			}
			public class Database
			{
				public List<Region> Regions;
				public List<Server> Servers;
				public List<Player> Players;
			}
			static void Main(string[] args)
			{
				var db = new Database
				{
					Regions = new List<Region>
					{
						new Region {Name = "EU"},
						new Region { Name = "US"}
					},
					Servers = new List<Server>
					{
						new Server { Name = "EuServer1", RegionName = "EU"},
						new Server { Name = "EuServer2", RegionName = "EU"},
						new Server { Name = "UsServer1", RegionName = "US"},
						new Server { Name = "UsServer2", RegionName = "US"}
					},
					Players = new List<Player>
					{
						new Player {Name = "EuName1", ServerName = "EuServer1", Scores = 1},
						new Player {Name = "EuName2", ServerName = "EuServer2", Scores = 2},
						new Player {Name = "UsName1", ServerName = "UsServer1", Scores = 3},
						new Player {Name = "UsName2", ServerName = "UsServer2", Scores = 4},
						new Player {Name = "UsName3", ServerName = "UsServer2", Scores = 5}
					}
				};
				// inserting new player
				db.Players.Add(new Player { Name = "newPlayer1", ServerName = "UsName2", Scores = 7 });
				// total scores by region
				foreach(var region in db.Regions)
				{
					var totalScore = from player in db.Players
									 join server in db.Servers on player.ServerName equals server.Name
									 where server.RegionName == region.Name
									 select player.Scores;
					Console.WriteLine($"Region: {region.Name}, Total Score: {totalScore.Sum()}");
				}
				// you can query whatever you want using LINQ...
			}
		}
	}
