    public static class TypeAccessorExtensions
    {
        public static void AssignValue<T>(this TypeAccessor accessor, T t, MemberSet members, string fieldName, object fieldValue)
        {
            var index = fieldName.IndexOf('.');
    
            if (index == -1)
            {
                if (members.Any(m => string.Equals(m.Name, fieldName, StringComparison.OrdinalIgnoreCase)))
                    accessor[t, fieldName] = fieldValue;
            }
            else
            {
                string fieldNameNested = fieldName.Substring(0, index);
                var member = members.FirstOrDefault(m => string.Equals(m.Name, fieldNameNested, StringComparison.OrdinalIgnoreCase));
    
                if (member != null)
                {
                    var nestedAccesor = TypeAccessor.Create(member.Type);
                    var tNested = accessor[t, fieldNameNested];
    
                    if (tNested == null)
                    {
                        tNested = Activator.CreateInstance(member.Type);
                        accessor[t, fieldNameNested] = tNested;
                    }
    
                    nestedAccesor.AssignValue(tNested, nestedAccesor.GetMembers(), fieldName.Substring(index + 1), fieldValue);
                }
    
            }
        }
    }
