    // Empty interface just to ensure that we get a compile
    // error if we pass a model that does not belong to our
    // payment system.
    public interface IPaymentModel { }
    public interface IPaymentService
    {
        void MakePayment<T>(T model) where T : IPaymentModel;
        bool AppliesTo(Type provider);
    }
    public interface IPaymentStrategy
    {
        void MakePayment<T>(T model) where T : IPaymentModel;
    }
