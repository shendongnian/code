     namespace MefMe
    {
        public interface IPlugin
        {
            void Alert();
        }
        [Export( typeof( IPlugin ) )]
        public class Plugin : IPlugin
        {
            private string code;
            [ImportingConstructor]
            public Plugin( [Import( "code" )] object code )
            {
                this.code = (string)code;
            }
            public void Alert() => Console.WriteLine( code );
        }
        public class Parameters
        {
            public static IEnumerable<Tuple<string, object>> PopulatedParameters { get; set; }
            [Export( "code", typeof( object ) )]
            public object code { get; set; }
            public Parameters()
            {
                foreach (var param in PopulatedParameters)
                    SetParameter( param.Item1, param.Item2 );
            }
            void SetParameter( string nameOfParam, object value )
            {
                var property = typeof( Parameters ).GetProperty( nameOfParam, BindingFlags.Public | BindingFlags.Instance );
                property.SetValue( this, value );
            }
        }
        public class Program
        {           
            static void Main( string[] args )
            {
                Parameters.PopulatedParameters = new Tuple<string, object>[] { new Tuple<string, object>( "code", "myvalue" ) };
                var config = new ContainerConfiguration()
                    .WithAssembly( typeof( IPlugin ).Assembly );
                var container = config.CreateContainer();
                // Throws a CompositionFailedException; see notes
                var plugin = container.GetExport<IPlugin>();
            }
        }
    }
