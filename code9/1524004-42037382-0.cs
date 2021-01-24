            var tableA = new List<string> {"A","D","R","B","A","E","B","Y"};
            var tableB = new List<string> { "A","E","B" };
            
            var result = tableA.Intersect(tableB).ToList();
            
            return tableA.Where(x=> result.Contains(x)).ToList();
