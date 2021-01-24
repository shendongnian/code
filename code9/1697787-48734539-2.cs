    public interface IPayModel { }  // Worth investigating into common shared methods and properties for this 
    public interface IPaymentService
    {
        void MakePayment(IPayModel  payModel);
    }
    public interface IPaymentService<T> : IPaymentService where T : IPayModel
    {
        void MakePayment(T payModel);  // Void here?  Is the status of the payment saved on the concrete pay model?  Why not an IPayResult?
    }
    
    public class CreditCardModel : IPayModel
    {
        public string CardHolderName { get; set; }
    }
    public class PayPalModel : IPayModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    
    public class CreditCardPayment : IPaymentService<CreditCardModel>
    {
        public void MakePayment(CreditCardModel payModel)
        {
            //Implmentation CreditCardPayment
        }
        void IPaymentService.MakePayment(IPayModel payModel)
        {
            MakePayment(payModel as CreditCardModel);
        }
    }
    public class PayPalPayment : IPaymentService<PayPalModel>
    {
        public void MakePayment(PayPalModel payModel)
        {
            //Implmentation PayPalPayment
        }
        void IPaymentService.MakePayment(IPayModel payModel)
        {
            MakePayment(payModel as PayPalModel);
        }
    }
    
    public enum PaymentType
    {
        PayPalPayment = 1,
        CreditCardPayment = 2
    }
