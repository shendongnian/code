    public abstract class PaymentService<TModel> : IPaymentService
        where TModel : IPaymentModel
    {
        public bool AppliesTo(Type provider)
        {
            return provider.Equals(typeof(TModel));
        }
        public void MakePayment<T>(T model) where T : IPaymentModel
        {
            MakePayment((TModel)(object)model);
        }
        protected abstract void MakePayment(TModel model);
    }
