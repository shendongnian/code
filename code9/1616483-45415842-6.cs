    static void Main(string[] args)
    {
        var entities = GetEntities("data.csv").ToList();
        File.WriteAllLines("4.txt", GetValues(entities, 4).Distinct());
        var values = GetValues(entities, 4).Union(GetValues(entities, 10));
        File.WriteAllLines("4-and-10.txt", Distinct(values));
    }
    private static IEnumerable<string> Distinct(IEnumerable<string> values)
    {
        var list = new List<string>();
        list.AddRange(values.Where(x => !list.Contains(x)));
        return list;
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
