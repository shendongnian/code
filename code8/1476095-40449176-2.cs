    public class Validator<T> : IValidator<T>
    {
        private readonly IEnumerable<IBusinessRule<T>> rules;
        public Validator(IEnumerable<IBusinessRule<T>> rules) {
            if (rules == null) throw new ArgumentNullException(nameof(rules));
            this.rules = rules;
        }
        public void Validate(T instance) {
            if (instance == null) throw new ArgumentNullException(nameof(instance));
            var errorMessages = rules.Select(rule => rule.Validate(instance)).ToArray();
            if (errorMessages.Any()) throw new ValidationException(errorMessages);
        }
    }
