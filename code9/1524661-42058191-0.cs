    public class Team
        {
            public Team ParentTeam;
            public string Name;
            int Level
            {
                get
                {
                    int i = 0;
                    Team p = this.ParentTeam;
                    while (p != null)
                    {
                        i++;
                        p = p.ParentTeam;
                    }
                    return i;
                }
            }
            static IEnumerable<Team> Sort(IEnumerable<Team> list)
            {
                return list.OrderBy(o => o.Level);
            }
        }
