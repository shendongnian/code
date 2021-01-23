    internal class MyJsonConverter : CustomCreationConverter<IControl>
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jObject = JObject.Load(reader);
            var controlType = jObject["CustomProperty"]?.Value<string>();
    
            IControl control = null;
    
            if (!string.IsNullOrWhiteSpace(controlType))
            {
                switch (controlType.ToLowerInvariant())
                {
                    case "controla":
                        control = Activator.CreateInstance(typeof(ControlA)) as IControl;
                        break;
                    case "controlb":
                        control = Activator.CreateInstance(typeof(ControlB)) as IControl;
                        break;
                }
            }
            if (controlType == null)
                throw new SerializationException($"Unable to deserialize property. {controlType}");
    
            serializer.Populate(jObject.CreateReader(), control);
            return control;
        }
    
        public override IControl Create(Type objectType)
        {
            return null;
        }
    }
    
    
    [JsonConverter(typeof(MyJsonConverter))]
    public interface IControl
    {
        string CustomProperty { get; set; }
    }
    
    public class Form
    {
        public IList<IControl> Controls { get; set; }
    }
    
    public class ControlA : IControl
    {
        public string CustomProperty { get; set; } = "ControlA";
    }
    public class ControlB : IControl
    {
        public string CustomProperty { get; set; } = "ControlB";
    }
    
    static void Main(string[] args)
    {
        var form = new Form();
        form.Controls = new List<IControl>();
        form.Controls.Add(new ControlA());
        form.Controls.Add(new ControlB());
        var json = JsonConvert.SerializeObject(form);
        var obj = JsonConvert.DeserializeObject<Form>(json);
    }
