    static void Main(string[] args)
    {
        var entities = GetEntities("data.csv").ToList();
        var columns = new[] { 4, 10 };
        var values = GetValues(entities, columns);
        File.WriteAllLines("4-and-10.txt", values.Distinct());
    }
    private static IEnumerable<string> GetValues(IEnumerable<Entity> entities, params int[] columns)
    {
        var values = new List<string>();
        foreach (var distinctValues in columns.Select(index => GetValues(entities, index).Distinct()))
        {
            values.AddRange(distinctValues);
        }
        return values;
    }
    private static IEnumerable<Entity> GetEntities(string file, char separator = ',')
    {
        return File.ReadAllLines(file).Select(x => new Entity
        {
            Values = x.Split(separator)
                .Select(c => c.Trim())
                .ToArray()
        });
    }
    public class Entity
    {
        public string[] Values { get; set; }
    }
