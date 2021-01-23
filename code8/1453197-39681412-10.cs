    [AttributeUsage(AttributeTargets.Property)]
    public class ValidateAttribute: Attribute
    {
    }
    public class Validator<TAttribute> where TAttribute : Attribute
    {
        private readonly Dictionary<Type, Predicate<object>> rules;
        public Validator()
        {
            rules = new Dictionary<Type, Predicate<object>>();
        }
        public bool UnregisterRule(Type t) => rules.Remove(t);
        public void RegisterRule<TRule>(Predicate<TRule> rule) => rules.Add(typeof(TRule), o => rule((TRule)o));
        public bool Validate<TTarget>(TTarget target, IList<string> failedValidationsBag, bool onlyExactTypeMathRules = false)
        {
            var valid = true;
            var properties = typeof(TTarget).GetProperties().Where(p => p.GetCustomAttribute<TAttribute>() != null);
            foreach (var p in properties)
            {
                var value = p.GetValue(target);
                Predicate<object> predicate = null;
                if (!rules.TryGetValue(p.PropertyType, out predicate) && !onlyExactTypeMathRules)  //check if there is an exact type match
                {
                    var assignableTypes = rules.Keys.Where(k => k.IsAssignableFrom(p.PropertyType)).ToList(); // there is no exact match. Check for valid reference conversions.
                    if (assignableTypes.Any())
                    {
                        if (assignableTypes.Count > 1)
                        {
                            int count = assignableTypes.Count;
                            while (assignableTypes.Count > 1)
                            {
                                assignableTypes = assignableTypes.Where(type => assignableTypes.Except(new[] { type }).All(otherType => !type.IsAssignableFrom(otherType))).ToList(); //Find the most specific reference coversion.
                                if (assignableTypes.Count == count) //We haven't made progress, can't decide which is a better match; rules are ambiguous. Bail out. This can happen with interfaces: IDisposable and IFormattable.
                                    throw new ArgumentException($"Ambiguous rules while processing {target}: {string.Join(", ", assignableTypes.Select(t => t.Name))}");
                                count = assignableTypes.Count;
                            }
                        }
                        predicate = rules[assignableTypes.Single()];
                    }
                }
                valid = checkRule(target, value, predicate, p.Name, failedValidationsBag) && valid;
            }
            return valid;
        }
        private bool checkRule<T>(T target, object value, Predicate<object> predicate, string propertyName, IList<string> failedValidationsBag)
        {
            if (predicate != null && !predicate(value))
            {
                failedValidationsBag.Add($"{target}: {propertyName} failed validation.");
                return false;
            }
            return true;
        }
    }
