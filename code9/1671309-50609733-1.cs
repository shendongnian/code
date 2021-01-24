    public class DestructureModels : IDestructuringPolicy
    {
        public bool TryDestructure( object value, ILogEventPropertyValueFactory propertyValueFactory, out LogEventPropertyValue result )
        {
            // to handle custom serialization of objects in the log messages
            //
            if( value.GetType().Namespace.Contains("MyProj.Models"))
            {
                result = new ScalarValue(JsonConvert.SerializeObject(value));
                return true;
            }
            else
            {
                result = null;
                return false;
            }
        }
    }
