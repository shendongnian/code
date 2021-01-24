    public class MyConfig
    {
        private readonly Dictionary<string, Dictionary<string, RestFunction>> _config = new Dictionary<string, Dictionary<string, RestFunction>>
        {
            [nameof( User )] = new Dictionary<string, RestFunction>
            {
                [nameof( UserSection.Add_User )] = new RestFunction { HttpMethod = "GET", ServiceString = "foo" },
                [nameof( UserSection.Get_Users_List )] = new RestFunction { HttpMethod = "GET", ServiceString = "foo" },
            },
            [nameof( Rights )] = new Dictionary<string, RestFunction>
            {
                [nameof( RightsSection.Approve_User_Rights )] = new RestFunction { HttpMethod = "GET", ServiceString = "foo" },
                [nameof( RightsSection.Get_Rights_List )] = new RestFunction { HttpMethod = "GET", ServiceString = "foo" },
            },
        };
        protected IDictionary<string, RestFunction> GetSectionValues( [CallerMemberName] string propertyName = null )
        {
            return _config[propertyName];
        }
        public UserSection User => new UserSection( GetSectionValues() );
        public RightsSection Rights => new RightsSection( GetSectionValues() );
    }
    public class RestFunction
    {
        public string HttpMethod { get; set; }
        public string ServiceString { get; set; }
    }
    public abstract class ConfigSectionBase
    {
        protected readonly IDictionary<string, RestFunction> _values;
        protected ConfigSectionBase( IDictionary<string, RestFunction> values )
        {
            _values = values;
        }
        protected RestFunction GetProperty( [CallerMemberName] string propertyName = null )
        {
            return _values[propertyName];
        }
    }
    public class UserSection : ConfigSectionBase
    {
        public UserSection( IDictionary<string, RestFunction> values ) : base( values )
        {
        }
        public RestFunction Add_User => GetProperty();
        public RestFunction Get_Users_List => GetProperty();
    }
    public class RightsSection : ConfigSectionBase
    {
        public RightsSection( IDictionary<string, RestFunction> values ) : base( values )
        {
        }
        public RestFunction Approve_User_Rights => GetProperty();
        public RestFunction Get_Rights_List => GetProperty();
    }
