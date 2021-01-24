    public class OrderValidator : IOrderValidator
    {
        private readonly IOrderValidator[] _subValidators;
        public OrderValidator(IOrderValidator[] subValidators)
        {
            _subValidators = subValidators;
        }
        public IEnumerable<ValidationMessage> GetValidationMessages(Order order)
        {
            var validationMessages = new List<ValidationMessage>();
            foreach(var validator in _subValidators)
            {
                validationMessages.AddRange(validator.GetValidationMessages(order));
            }
            return validationMessages;
        }
    }
