    //AllAccounts.cs:
    using System;
    using System.Collections;
    using System.Runtime.InteropServices;
    namespace BankServerCSharp
    {
      [ComVisible(true)]  // This is mandatory.
      [InterfaceType(ComInterfaceType.InterfaceIsDual)]
      public interface IAllAccounts
      {
        int Count{ get; }
        [DispId(0)]
        IAccount Item(int i);
        [DispId(-4)]
        IEnumerator GetEnumerator();
        Account AddAccount();
        void RemoveAccount(int i);
        void ClearAllAccounts();
      }
      [ComVisible(true)]  // This is mandatory.
      [ClassInterface(ClassInterfaceType.None)]
      public class AllAccounts:IAllAccounts 
      {
        private AllAccounts(){ } // private constructor, coclass noncreatable
        private List<IAccount> Al = new List<IAccount>();
        public static AllAccounts MakeAllAccounts() { return new AllAccounts(); }
        //public, but not exposed to COM
        public IEnumerator GetEnumerator() { return Al.GetEnumerator();  }
        
        public int Count { get { return Al.Count; } }
        public IAccount Item(int i)  { return (IAccount)Al[i - 1];  }
        public Account AddAccount() { Account acc = Account.MakeAccount();
                                            Al.Add(acc); return acc; }
        public void RemoveAccount(int i) {  Al.RemoveAt(i - 1);  }
        public void ClearAllAccounts() { Al.Clear(); }
      }
    }
