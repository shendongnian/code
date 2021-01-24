        var maillist = from p in persons
                           group p by p.Email into grp
                           select new { grp.Key, Names=grp.Select(g => g.Name).ToArray() };
                 foreach( var entry in maillist)
                {
                    Console.WriteLine($"EMail: {entry.Key} Names: {string.Join<string>(",", entry.Names)}" );
                }
