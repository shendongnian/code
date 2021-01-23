    public class Properties
    {
        public string Prop1;
        public string[] Prop2;
    }
    public List<Properties> GetProperties()
    {
            var list = new List<Properties>();
            var props = new[] { "abc", "xyz", }.toList();
            props.ForEach(p=>{
                var np = new Properties { Prop1 = "Prop" + i, Prop2 = props};
                list.Add(np);
            });
            return list;
    }
    var values = GetProperties().Select(x => new {
                        prop = x.Prop2.ToString()
                    }).ToList();
