    public class Rule<T>
    {
        private readonly Predicate<T> rule;
        public Rule(Predicate<T> predicate)
        {
            rule = predicate;
        }
        public bool Validate(CreditCard card) => Rule(card);
     }
