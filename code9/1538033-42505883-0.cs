    public class ServiceClass
    {
        public enum ServiceID
        {
            OneKWithdrawal,
            Ten_KWithdrawal,
            BTWithdrawal,
            OneKDeposit,
            Ten_KDeposit,
            BTDeposit
        }
        public ServiceID From_Ser_ID { get; set; }
        public ServiceID To_Ser_ID { get; set; }
        public void One_KWithdrawal()
        { Console.WriteLine("One_KWithdrawal"); }
        public void Ten_KWithdrawal()
        { Console.WriteLine("Ten_KWithdrawal"); }
        public void BTWithdrawal()
        { Console.WriteLine("BTWithdrawal"); }
        public void One_KDeposit()
        { Console.WriteLine("One_KDeposit"); }
        public void Ten_KDeposit()
        { Console.WriteLine("Ten_KDeposit"); }
    }
