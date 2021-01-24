    public class MyTestImplementation : IAccountService
    {
        public bool HasBeenCalled { get; private set; }
        public int ProvidedId { get; private set; }
        public double GetAccountAmount(int accountId)
        {
            HasBeenCalled = true;
            ProvidedId = accountId;
        }
    }
