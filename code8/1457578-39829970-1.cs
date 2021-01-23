    public class FieldCollection
    {
        public FieldCollection()
        {
            Fields = new List<FieldBase>();
        }
    
        public List<FieldBase> Fields { get; set; }
    
        public void SetFieldValue<T>(string fieldName, T value)
        {
            var field = FindField<T>(fieldName);
    
    		field.SetValue(value);
        }
    
        public Field<T> FindField<T>(string fieldName)
        {
            return Fields.OfType<Field<T>>()
    			.FirstOrDefault(f => (String.Equals(f.Name, fieldName, StringComparison.CurrentCultureIgnoreCase)));
        }
    }
    
    public abstract class FieldBase
    {
        public string  Name { get; set; }
    }
    
    public class Field<T> : FieldBase
    {
        public void SetValue(T value)
        {
        }
    }
