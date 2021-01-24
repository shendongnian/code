    public interface IPaymentService
    {
        IPayModel CreatePayModel();
        void MakePayment(IPayModel payModel);
    }
    public interface IPaymentService<T> : IPaymentService where T : IPayModel
    {
        new T CreatePayModel();
        void MakePayment(T payModel);
    }
    public class CreditCardPayment : IPaymentService<CreditCardModel>
    {
        public CreditCardModel CreatePayModel()
        {
            return new CreditCardModel();
        }
        public void MakePayment(CreditCardModel payModel)
        {
            //Implmentation CreditCardPayment
        }
    
        IPayModel IPaymentService.CreatePayModel()
        {
            return CreatePayModel();
        }
        void IPaymentService.MakePayment(IPayModel payModel)
        {
            MakePayment(payModel as CreditCardModel);
        }
    } 
