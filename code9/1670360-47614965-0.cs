    public class DynamicClass : DynamicObject
    {
        private Dictionary<String, KeyValuePair<Type, Object>> m_Fields;
    
        public DynamicClass(List<Field> fields)
        {
            m_Fields = new Dictionary<String, KeyValuePair<Type, Object>>();
    
            fields.ForEach(x => m_Fields.Add
            (
                x.FieldName,
                new KeyValuePair<Type, Object>(x.FieldType, null)
            ));
        }
    
        public override Boolean TryGetMember(GetMemberBinder binder, out Object result)
        {
            if (m_Fields.ContainsKey(binder.Name))
            {
                result = m_Fields[binder.Name].Value;
                return true;
            }
    
            result = null;
            return false;
        }
    
        public override Boolean TrySetMember(SetMemberBinder binder, Object value)
        {
            if (m_Fields.ContainsKey(binder.Name))
            {
                Type type = m_Fields[binder.Name].Key;
    
                if (value.GetType() == type)
                {
                    m_Fields[binder.Name] = new KeyValuePair<Type, Object>(type, value);
                    return true;
                }
            }
    
            return false;
        }
    }
