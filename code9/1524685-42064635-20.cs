        public static IEnumerable<Team> OrderByChild(this List<Team> l)
        {
            int count = l.Count;
            Team start = l.First(x => x.ParentTeam == null);
            Team[] res = new Team[count];
            res[count - 1] = start;
            for (int i = count - 2; i >= 0; i--)
            {
                start = start.ChildTeam;
                res[i] = start;
            }
            return res;
        }
