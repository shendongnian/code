    var dt = new DataTable();
            dt.Columns.Add(new DataColumn("TimeSlot", typeof(string)));
            dt.Columns.Add(new DataColumn("GameID", typeof(string)));
            dt.Columns.Add(new DataColumn("TeamAID", typeof(string)));
            dt.Columns.Add(new DataColumn("TeamAName", typeof(string)));
            dt.Columns.Add(new DataColumn("TeamBID", typeof(string)));
            dt.Columns.Add(new DataColumn("TeamBName", typeof(string)));
            	
            XDocument xdoc = XDocument.Load(@"c:/matchdata.xml");
            var games = from i in xdoc.Descendants("Match")
            	select new //creates a few new anonymous types to store values to dump into the datatable
            {
            	TimeSlot = (string)i.Element("TimeSlot"),
            	GameID = (string)i.Element("Game_Id"),
            	TeamAID = (string)i.Element("ArrayOfTeams").Element("Team").Element("Team_id"),
            	TeamAName = (string)i.Element("ArrayOfTeams").Element("Team").Element("Team_Name"),
            	TeamBID = (string)i.Element("ArrayOfTeams").Elements("Team").Skip(1).First().Element("Team_id"), //skips a node to collect info for the next team.
            	TeamBName = (string)i.Element("ArrayOfTeams").Elements("Team").Skip(1).First().Element("Team_Name") //skips a node to collect info for the next team.
            };          
            foreach (var item in games)
            {
            	dt.Rows.Add(item.TimeSlot, item.GameID, item.TeamAID, item.TeamAName, item.TeamBID, item.TeamBName); //adds a new row of data into the datatable for every <Match> </Match>
            }
