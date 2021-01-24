    var links = new List<Links>
                {
                    new Links{FromNode = "B", ToNode = "C"},
                    new Links{FromNode = "C", ToNode = "B"},
                    new Links{FromNode = "A", ToNode = "D"}
                };
            var res = from a in links
                      join b in links
                      on
                      new { FromNode = a.FromNode, ToNode = a.ToNode } equals
                      new { FromNode = b.ToNode, ToNode = b.FromNode }
                      select new { a.FromNode, a.ToNode };
