          foreach (string Zone in Zones) {
				Console.WriteLine("Zone: " + Zone);
                // Find teams in this zone
				Teams[] Ts = (from t in ownersArray where t.zone == Zone select t).ToArray();
				foreach (Teams T in Ts) {
					foreach (Player P in T.players.Where(x=>x.type == "Kepper") {
                        // print players in this zone who are keepers
						Console.WriteLine(P.name);
					}
				}
			}
