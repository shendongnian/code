    using System.Collections.Generic;
    using System.Linq;
    
    namespace LinqTest01
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<Server> servers = new List<Server>{
                    new Server(){ load = null, distance = 3 },
                    new Server(){ load = 0.1, distance = 3 },
                    new Server(){ load = 0.6, distance = 3 },
                    new Server(){ load = 0.2, distance = 3 },
                    new Server(){ load = 0.7, distance = 1 },
                    new Server(){ load = 0.1, distance = 1 },
                    new Server(){ load = 0.2, distance = 1 },
                    new Server(){ load = 0.1, distance = 2 },
                    };
    
                // option 1
                var sorted = from server in servers orderby server.load where server.load != null select server;
                var groups = from server in sorted
                           group server by server.distance into bydistance
                           orderby bydistance.Key
                           select bydistance
                           ;
    
                var final1 = Zip(groups);
    
                // option 2
                var orderedbyLoad = servers.OrderBy(t => t.load);
                var groupByDistance = orderedbyLoad.GroupBy(a => a.distance, s => s);
                var final2 = Zip(groups);
            }
    
            static IEnumerable<Server> Zip(IEnumerable<IEnumerable<Server>> groups)
            {
                bool cont;
                int i = 0;
                do
                {
                    cont = false;
                    foreach (var grp in groups)
                    {
                        var element = grp.Skip(i).FirstOrDefault();
                        if (element != null)
                        {
                            cont = true;
                            yield return element;
                        }
                    }
                    ++i;
                } while (cont);
            }
        }
    
        class Server
        {
            public double? load;
            public int distance;
        }
    
    }
