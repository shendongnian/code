    public class PaymentStrategy : IPaymentStrategy
    {
        private readonly IEnumerable<IPaymentService> paymentServices;
        public PaymentStrategy(IEnumerable<IPaymentService> paymentServices)
        {
            if (paymentServices == null)
                throw new ArgumentNullException(nameof(paymentServices));
            this.paymentServices = paymentServices;
        }
        public void MakePayment<T>(T model) where T : IPaymentModel
        {
            GetPaymentService(model).MakePayment(model);
        }
        private IPaymentService GetPaymentService<T>(T model) where T : IPaymentModel
        {
            var result = paymentServices.FirstOrDefault(p => p.AppliesTo(model.GetType()));
            if (result == null)
            {
                throw new InvalidOperationException(
                    $"Payment service for {model.GetType().ToString()} not registered.");
            }
            return result;
        }
    }
