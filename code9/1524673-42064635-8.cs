        public static IEnumerable<Team> FindAscendants(this IEnumerable<Team> l, Team from)
        {
            Team t = l.FirstOrDefault(x => 
                (x.ParentTeam?.Name ?? "").Equals(from?.Name ?? ""));
            return new List<Team>() { t }.Concat(t != null ?
                l.FindAscendants(t) : Enumerable.Empty<Team>());
        }
