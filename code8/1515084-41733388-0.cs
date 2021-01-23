    public interface IControl { }
    
    public class Form
    {
        public IList<IControl> Controls { get; set; }
    }
    
    public class ControlA : IControl { }
    public class ControlB : IControl { }
    
    static void Main(string[] args)
    {
        var form = new Form();
        form.Controls = new List<IControl>();
    
        form.Controls.Add(new ControlA());
        form.Controls.Add(new ControlB());
        var json = JsonConvert.SerializeObject(form, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
        var obj = JsonConvert.DeserializeObject<Form>(json, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
    }
