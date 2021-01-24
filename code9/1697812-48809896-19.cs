    public class CreditCardModel : IPaymentModel
    {
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public int ExpirtationMonth { get; set; }
        public int ExpirationYear { get; set; }
    }
    public class PayPalModel : IPaymentModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
