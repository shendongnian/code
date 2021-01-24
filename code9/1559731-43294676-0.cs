    public class Account{
       private Decimal Balance; // Since you mentioned this private field is a MUST
       public Decimal GetBalance() {
           return Balance;
       }
       // Or public depending on your needs
       protected void SetBalance(Decimal Balance) {
           this.Balance = Balance; 
       }
    }
