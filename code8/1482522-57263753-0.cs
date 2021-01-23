    public static class ReflectionExtensions
    {
        public static void SetValue(this MemberInfo mi, object targetObject, object value)
        {
            try
            {
                if (mi.MemberType == MemberTypes.Field)
                {
                    (mi as FieldInfo).SetValue(targetObject, value);
                }
                else
                {
                    (mi as PropertyInfo).SetValue(targetObject, value);
                }
            }
            catch(Exception e)
            {
                throw new InvalidOperationException($"MemberInfo must be a subtype of FieldInfo or PropertyInfo.");
            }
        }
    }
