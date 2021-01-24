        public class Test
        {
            public int Id { get; set; }
            public DateTime TestDate { get; set; }
            public ICollection<Level> Levels { get; set; }
        }
        public class Level
        {
            public int Id { get; set; }
            public ICollection<LevelDetail> LevelDetails { get; set; }
        }
        public class LevelDetail
        {
            public int Id { get; set; }
            public DateTime LevelDate { get; set; }
        }
        ...
        // These results are the same and have the same expression trees
        var resultByInclude = context.Tests
            .Include(o => o.Levels)
            .ThenInclude(p => p.LevelDetails).ToList();
        var resultBySelect = GetQueryWithIncludes(context.Tests,
            o => o.Levels.Select(p => p.LevelDetails)).ToList();
