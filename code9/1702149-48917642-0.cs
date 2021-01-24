    internal class Program
    {
        static void Main(string[] args)
        {
            var statements = new List<Statement>()
            {
                new Statement(1, "a", "apple"),
                new Statement(1, "a", "banana"),
                new Statement(1, "b", "potato"),
                new Statement(2, "c", "car"),
                new Statement(2, "c", "bus"),
                new Statement(2, "d", "plane")
            };
            var sectionCollections = statements
                .GroupBy(s => s.Section)
                .Select(group => new SectionCollection(group.Key, statements))
                .ToList();
        }
        public class Statement
        {
            public Statement(int section, string category, string statementName)
            {
                Section = section;
                Category = category;
                StatementName = statementName;
            }
            public int Section { get; }
            public string Category { get; }
            public string StatementName { get; }
        }
        public class SectionCollection
        {
            public SectionCollection(int sectionName, List<Statement> statements)
            {
                SectionName = sectionName;
                Categories = statements
                    .GroupBy(s => s.Category)
                    .Select(group => new CategoryCollection(group.Key, group.ToList()))
                    .ToList();
            }
            public int SectionName { get; }
            public List<CategoryCollection> Categories { get; }
        }
        public class CategoryCollection
        {
            public CategoryCollection(string categoryName, List<Statement> statements)
            {
                CategoryName = categoryName;
                Statements = statements;
            }
            public string CategoryName { get; }
            public List<Statement> Statements { get; }
        }
    }
