        public static IEnumerable<Team> FindDescendandOptimized(this List<Team> l, Team from)
        {
            int count = l.Count;
            var dic = l.ToDictionary(x => x.ParentTeam?.Name??"");
            Team start = dic[from?.Name??""];
            Team[] res = new Team[count];
            res[count - 1] = start;
            for (int i = count - 2; i >= 0; i--)
            {
                start = dic[start.Name];
                res[i] = start;
            }
            return res;
        }
