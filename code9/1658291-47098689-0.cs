    public static class ObjectMorpher
    {
        public class InvalidMorphException : Exception
        {
        }
        [AttributeUsage(AttributeTargets.Property)]
        public class IgnoredOnMorphAttribute : Attribute
        {
        }
        public static TargetType Morph<TargetType>(this object source, TargetType dest, Func<string, string> propertyMatcher = null, bool failOnNoMatch = false)
            where TargetType : class
        {
            if (source == null || dest == null)
                throw new ArgumentNullException();
            foreach (var sourceProp in source.GetType().GetProperties().Where(x => x.GetCustomAttributes<IgnoredOnMorphAttribute>().Any() == false))
            {
                var destProp = typeof(TargetType).GetProperties().Where(x => x.Name == ((propertyMatcher == null) ? sourceProp.Name : propertyMatcher(sourceProp.Name))).FirstOrDefault();
                //check property exists
                if (destProp == null)
                {
                    if (failOnNoMatch)
                        throw new InvalidMorphException();
                    else
                        continue;
                }
                //check value type is assignable
                if (!destProp.GetType().IsAssignableFrom(sourceProp.GetType()))
                {
                    if (failOnNoMatch)
                        throw new InvalidMorphException();
                    else
                        continue;
                }
                destProp.SetValue(dest, sourceProp.GetValue(source));
            }
            return dest;
        }
    }
