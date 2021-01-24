        client.BigDB.LoadRange("Clans", "ByName", null, startAt + "0000000000", stopAt + "zzzzzzzzzz", 1000, delegate (DatabaseObject[] o)
        {
            var sb = new StringBuilder();
            foreach (DatabaseObject obj in o)
            {
                var name = obj.GetString("name");
                ClanNames.Add(name);
                sb.Append(name);
            }      
            main.ui.AppendTestBox(sb.ToString());
          
        });
