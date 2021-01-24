    using System;
    using System.Reflection;
    using System.Linq;
    
    public class C {
        [ObsoleteAttribute]
        private string P {get; set;}
    }
    
    public class C2
    {
        String x = typeof(C)
            .GetProperties((BindingFlags)62)
            .Single(x => x.GetCustomAttribute<ObsoleteAttribute>() != null)
            .Name;
    }
