    public class EnumModel<T>
    {
        public string StringValue { get; set; }
        public T EnumValue { get; set; }
        public int IntValue { get; set; }
        public string DisplayName { get; set; }
        public static List<EnumModel<T>> GetModel()
        {
            var t = typeof(T);
            var fields = t.GetFields();
            return  fields.Where(x => x.CustomAttributes.Any(z => z.NamedArguments.Any(n => n.MemberName == "Name"))).Select(x =>
            new EnumModel<T>
            {
                StringValue = x.Name,
                EnumValue = (T)Enum.Parse(t, x.Name),
                IntValue = (int)Enum.Parse(t, x.Name),
                DisplayName = (string)x.CustomAttributes.Select(z => z.NamedArguments.First(n => n.MemberName == "Name").TypedValue).First().Value,
            }).ToList();
        }
    }
