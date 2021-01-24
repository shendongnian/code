    public class Foo
    {
        private int field1 = 1;
        private int field2 = 2;
        private int field3 = 3;
        public int GetValueOf(string field)
        {
            FieldInfo f = this.GetType().GetTypeInfo().GetField(field, 
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            return (int)f.GetValue(this);
        }
        
    }
