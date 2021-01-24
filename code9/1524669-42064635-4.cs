        public static IEnumerable<Team> FindAscendants(this IEnumerable<Team> l, Team from)
        {
            Team t = l.FirstOrDefault(x => 
                (x.ParentTeam?.Name ?? "").Equals(from?.Name ?? ""));
            yield return t;
            if (t != null)
                foreach (Team r in l.FindAscendants(t))
                {
                    yield return r;
                }
        }
