        public static IEnumerable<Team> FindAscendandOptimized(this List<Team> l, Team from)
        {
            int count = l.Count;
            var dic = l.ToDictionary(x => x.ParentTeam?.Name??"");
            Team start = dic[from?.Name??""];
            Team[] res = new Team[count];
            res[0] = start;
            for (int i = 1; i < count; i++)
            {
                start = dic[start.Name];
                res[i] = start;
            }
            return res;
        }
