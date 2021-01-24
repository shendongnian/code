    static class Program
    {
        static void Main(object[] args)
        {
            IPaymentService paymentStrategy = null;
            paymentStrategy = GetPaymentOption((PaymentType)1);
            paymentStrategy.MakePayment(new PayPalModel { UserName = "", Password = "" });
    
            paymentStrategy = GetPaymentOption((PaymentType)2);
            paymentStrategy.MakePayment(new CreditCardModel { CardHolderName = "Aakash" });
    
            Console.ReadLine();
        }
    
        private static IPaymentService GetPaymentOption(PaymentType paymentType) 
        {
            switch (paymentType)
            {
                case PaymentType.PayPalPayment:
                    return new PayPalPayment();
                case PaymentType.CreditCardPayment:
                    return new CreditCardPayment();
                default:
                    throw new NotSupportedException($"Payment Type '{paymentType.ToString()}' Not Supported");
            }
        }
    }
