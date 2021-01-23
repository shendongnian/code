    [AttributeUsage(AttributeTargets.Property)]
    public class ValidateAttribute: Attribute
    {
    }
    public class Validator<T>
    {
        private readonly Dictionary<Type, Predicate<object>> rules;
        public Validator()
        {
            rules = new Dictionary<Type, Predicate<object>>();
        }
        public bool UnregisterRule(Type t) => rules.Remove(t);
        public void RegisterRule<TRule>(Predicate<TRule> rule) => rules.Add(typeof(TRule), o => rule((TRule)o));
        public bool Validate(T target, IList<string> failedValidationsBag)
        {
            var valid = true;
            var properties = typeof(T).GetProperties().Where(p => p.GetCustomAttribute<ValidateAttribute>() != null);
            foreach (var p in properties)
            {
                var value = p.GetValue(target);
                //check if exact type has validator
                Predicate<object> predicate = null;
                if (!rules.TryGetValue(p.PropertyType, out predicate))
                {
                    //check if an assignable type exists
                    var assignableTypes = rules.Keys.Where(k => k.IsAssignableFrom(p.PropertyType)).ToList();
                    if (assignableTypes.Any())
                    {
                        if (assignableTypes.Count > 1)
                        {
                            //Get the most specific type
                            int count = assignableTypes.Count;
                            while (assignableTypes.Count > 1)
                            {
                                assignableTypes = assignableTypes.Where(type => assignableTypes.Except(new[] { type }).All(otherType => !type.IsAssignableFrom(otherType))).ToList();
                                if (assignableTypes.Count == count) //we haven't made progress.
                                    throw new ArgumentException($"Ambigous rules: {string.Join(", ", assignableTypes.Select(t => t.Name))}");
                                count = assignableTypes.Count;
                            }
                        }
                        predicate = rules[assignableTypes.Single()];
                    }
                }
                valid = checkRule(value, predicate, p.Name, failedValidationsBag) && valid;
            }
            return valid;
        }
        private bool checkRule(object value, Predicate<object> predicate, string propertyName, IList<string> failedValidationsBag)
        {
            if (predicate != null && !predicate(value))
            {
                failedValidationsBag.Add($"{typeof(T).Name}.{propertyName} failed validation.");
                return false;
            }
            return true;
        }
    }
