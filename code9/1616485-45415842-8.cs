    static void Main(string[] args)
    {
        var entities = GetEntities("data.csv").ToList();
        File.WriteAllLines("4.txt", GetValues(entities, 4).Distinct());
        File.WriteAllLines("10.txt", GetValues(entities, 10).Distinct());
        var columns = new[] {4, 10};
        var values = GetValues(entities, columns);
        File.WriteAllLines("4-and-10.txt", values.Distinct());
    }
    private static IEnumerable<string> GetValues(IEnumerable<Entity> entities,
                                                 IEnumerable<int> columns)
    {
        var values = new List<string>();
        foreach (var distinctValues in columns.Select(
                        index => GetValues(entities, index).Distinct()))
        {
            values.AddRange(distinctValues);
        }
        return values;
    }
    private static IEnumerable<string> GetValues(IEnumerable<Entity> entities, int column)
    {
        return entities.Select(x => x.Values[column]);
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
