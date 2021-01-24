    List<string> testList = new List<string>() { "A", "A", "A", "B", "O", "A" };
    List<string> cart = new List<string>() { "O", "A", "A", "B", "O", "A", "S" };
            var Lists = new[]
            {
                testList,
                cart,
                new List<string>() { "A", "A" },
                new List<string>() { "A", "S" }
            };
            IEnumerable<int> answer = from x in Lists[0]
                                      join y in Lists[3] on x.IndexOf("A") equals y.IndexOf("A")
                                      select x.Length + y.Length;
