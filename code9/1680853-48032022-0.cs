    public class Configuration: IConfiguration
    {
       public Configuration
       {
         this.Foo = ConfigurationManager.AppSettings["MyConfig"];
       }
       public string Foo { get; private set; }
       public bool IsMatch(string str) { return string.Equals(str, this.Foo, StringComparison.OrdinalIgnoreCase); } } 
    }
