    Account.cs:
    using System.Runtime.InteropServices;
    namespace BankServerCSharp
    {
      [ComVisible(true)]  // This is mandatory.
      [InterfaceType(ComInterfaceType.InterfaceIsDual)]
      public interface IAccount
      {
        double Balance { get; } // A property
        void Deposit(double b); // A method
      }
      [ComVisible(true)]  // This is mandatory.
      [ClassInterface(ClassInterfaceType.None)]
      public class Account:IAccount
      {
        private double mBalance = 0;
        private Account() { }     // private constructor, coclass noncreatable
        public static Account MakeAccount() { return new Account(); }
        //MakeAccount is not exposed to COM, but can be used by other classes
        public double Balance  { get {  return mBalance; } }
        public void Deposit(double b) { mBalance += b; }
      }
    }
    Bank.cs:
    using System.Runtime.InteropServices;
    namespace BankServerCSharp
    {
      [ComVisible(true)]  // This is mandatory.
      [InterfaceType(ComInterfaceType.InterfaceIsDual)]
      public interface IBank { IAllAccounts Accounts { get; }  }
      [ComVisible(true)]  // This is mandatory.
      [ClassInterface(ClassInterfaceType.None)]
      public class Bank:IBank
      {
        private readonly AllAccounts All;
        public Bank() {  All = AllAccounts.MakeAllAccounts(); } 
        public IAllAccounts Accounts {  get { return All; } }
      }
    }
