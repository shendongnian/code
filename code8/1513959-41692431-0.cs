    [DebuggerDisplay("{value}", Name = "{key}")]
    public class KeyValuePairs
    {
       private object key;
       private object value;
       public KeyValuePairs(object key, object value)
       {
           this.value = value;
           this.key = key;
       }
    }
