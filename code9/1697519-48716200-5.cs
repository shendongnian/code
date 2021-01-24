    public class OrderValidator : IOrderValidator
    {
        private readonly IOrderValidator[] _subValidators;
        public OrderValidator(IOrderValidator[] subValidators)
        {
            _subValidators = subValidators;
        }
        public IEnumerable<ValidationMessage> GetValidationMessages(Order order)
        {
            return _subValidators.Select(
                validator => validator.GetValidationMessages(order).ToArray())
                .SelectMany(validationMessage => validationMessage);
        }
    }
