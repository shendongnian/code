    public class CustomPropertiesContractResolver : DefaultContractResolver
    {
        private HashSet<string> _propertySet;
        public CustomPropertiesContractResolver(IEnumerable<string> propertyNames)
        {
            if (propertyNames != null)
            {
                _propertySet = new HashSet<string>(propertyNames, StringComparer.OrdinalIgnoreCase);
            }
        }
        protected override List<MemberInfo> GetSerializableMembers(Type objectType)
        {
            List<MemberInfo> serializableMembers = null;
            var allMembers = base.GetSerializableMembers(objectType);
            if (_propertySet != null && _propertySet.Count > 0)
            {
                serializableMembers = allMembers.Where(m => !_propertySet.Contains(m.Name)).ToList();
            }
            return serializableMembers != null && serializableMembers.Count > 0 ? serializableMembers : allMembers;
        }
    }
