    static void Main(string[] args)
        {
            List<TableA> tableA = new List<TableA>
            {
                new TableA { Id = 1, A = "a", B = "b", C = "c", DataAmt = 1, Value = 1 },
                new TableA { Id = 2, A = "a", B = "b", C = "c", DataAmt = 1, Value = 1 },
                new TableA { Id = 3, A = "a", B = "b", C = "c", DataAmt = 2, Value = 2 },
                new TableA { Id = 4, A = "a", B = "b", C = "c", DataAmt = 2, Value = 2 },
                new TableA { Id = 5, A = "a", B = "b", C = "c", DataAmt = 2, Value = 2 },
            };
            List<TableB> tableB = new List<TableB>
            {
                new TableB { Id = 1, A = "a", B = "b", C = "c" },
                new TableB { Id = 2, A = "a", B = "b", C = "c" },
                new TableB { Id = 3, A = "a", B = "b", C = "c" },
            };
            
            var result = tableA.Where(x => x.Value > 1 && tableB.Any(y => y.A == x.A && y.B == x.B && y.C == x.C)).Select(x => new
            {
                A = x.A,
                B = x.B,
                C = x.B,
                DataAmt = x.DataAmt
            }).Distinct().ToList();
        }
