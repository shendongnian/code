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
        public bool Validate<TTarget>(TTarget target, IList<string> failedValidationsBag, bool onlyExactTypeMatchRules = false)
        {
            var valid = true;
            var properties = typeof(TTarget).GetProperties().Where(p => p.GetCustomAttribute<TAttribute>() != null);
            foreach (var p in properties)
            {
                var value = p.GetValue(target);
                Predicate<object> predicate = null;
                //Rule aplicability works as follows:
                //
                //1. If the type of the property matches exactly the type of a rule, that rule is chosen and we are finished.
                //   If no exact match is found and onlyExactMatchRules is true no rule is chosen and we are finished.
                //
                //2. Build a candidate set as follows: If the type of a rule is assignable from the type of the property,
                //   add the type of the rule to the candidate set.
                //   
                //   2.1.If the set is empty, no rule is chosen and we are finished.
                //   2.2 If the set has only one candidate, the rule with that type is chosen and we're finished.
                //   2.3 If the set has two or more candidates, keep the most specific types and remove the rest.
                //       The most specific types are those that are not assignable from any other type in the candidate set.
                //       Types are removed from the candidate set until the set either contains one single candidate or no more
                //       progress is made.
                //
                //       2.3.1 If the set has only one candidate, the rule with that type is chosen and we're finished.
                //       2.3.2 If no more progress is made, we have an ambiguous rules scenario; there is no way to know which rule
                //             is better so an ArgumentException is thrown (this can happen for example when we have rules for two
                //             interfaces and an object subject to validation implements them both.) 
                Type ruleType = null;
                if (!rules.TryGetValue(p.PropertyType, out predicate) && !onlyExactTypeMatchRules)
                {
                    var candidateTypes = rules.Keys.Where(k => k.IsAssignableFrom(p.PropertyType)).ToList();
                    var count = candidateTypes.Count;
                    if (count > 0)
                    {
                        while (count > 1)
                        {
                            candidateTypes = candidateTypes.Where(type => candidateTypes.Where(otherType => otherType != type)
                                                           .All(otherType => !type.IsAssignableFrom(otherType)))
                                                           .ToList();
                            if (candidateTypes.Count == count) 
                                throw new ArgumentException($"Ambiguous rules while processing {target}: {string.Join(", ", candidateTypes.Select(t => t.Name))}");
                            count = candidateTypes.Count;
                        }
                        ruleType = candidateTypes.Single();
                        predicate = rules[ruleType];
                    }
                }
                valid = checkRule(target, ruleType ?? p.PropertyType, value, predicate, p.Name, failedValidationsBag) && valid;
            }
            return valid;
        }
        private bool checkRule<T>(T target, Type ruleType, object value, Predicate<object> predicate, string propertyName, IList<string> failedValidationsBag)
        {
            if (predicate != null && !predicate(value))
            {
                failedValidationsBag.Add($"{target}: {propertyName} failed validation. [Rule: {ruleType.Name}]");
                return false;
            }
            return true;
        }
    }
