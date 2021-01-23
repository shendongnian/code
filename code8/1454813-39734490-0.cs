    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace TeamTree
    {
        public class Team
        {
            public int Id { get; private set; }
            public Team Parent { get; private set; }
    
            public Team(int id, Team parent)
            {
                this.Id = id;
                this.Parent = parent;
            }
    
            public IEnumerable<int> Teams()
            {
                yield return this.Id;
    
                if (this.Parent != null)
                    foreach (int id in Parent.Teams())
                        yield return id;
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                var highLevelTeam = new Team(12, null);
                var nextLevelTeam = new Team(10, highLevelTeam);
                var lowLevelTeam = new Team(6, nextLevelTeam);
    
                Console.WriteLine(@"lowLevelTeam ({0})", lowLevelTeam.Teams().Aggregate("", (r, id) => r + ", " + id.ToString()).Substring(2));
                Console.WriteLine(@"nextLevelTeam ({0})", nextLevelTeam.Teams().Aggregate("", (r, id) => r + ", " + id.ToString()).Substring(2));
                Console.WriteLine(@"highLevelTeam ({0})", highLevelTeam.Teams().Aggregate("", (r, id) => r + ", " + id.ToString()).Substring(2));
                Console.ReadLine();
            }
        }
    }
