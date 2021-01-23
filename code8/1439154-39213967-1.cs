    public class DeserializedJsonClass
    {
        public IEnumerable<EvaluationStat> Evaluations {get;set;}
    }
    
    public class EvaluationStat
    {
        public string Name {get;set;}
        public char Type {get;set;}
        public int Confidence {get;set;}
    }
    // ...
    private static DeserializedJsonClass Deserialize(string json)
    {
        // using Newtonsoft.Json
        dynamic deserialized = JsonConvert.DeserializeObject(json);
        DeserializedJsonClass result = new DeserializedJsonClass();
        result.Evaluations = FetchEvaluations(deserialized);
        return result;
    }
    private static IEnumerable<EvaluationStat> FetchEvaluations(dynamic json)
    {
        ICollection<string> names = new List<string>();
        ICollection<char> types = new List<char>();
        ICollection<int> confidences = new List<int>();
 
        foreach (var prop in json)
        {
            if (prop.Name.StartsWith("Name"))
               names.Add((string)prop.Value.Value);
            else if (prop.Name.StartsWith("Type"))
               types.Add(Convert.ToChar((string)prop.Value.Value));
            else if (prop.Name.StartsWith("Confidence"))
               confidences.Add(Convert.ToInt32((string)prop.Value.Value));
        }
        return names.Zip(types, (n, t) => new { Name = n, Type = t })
                    .Zip(confidences, (l, c) => new { Name = l.Name, Type = l.Type, Confidence = c })
                    .Select(t => new EvaluationStat()
        {
            Name = t.Name,
            Type = t.Type,
            Confidence = t.Confidence
        });
    }
