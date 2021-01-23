    public interface ILoan : ILoanBase<Debt>  // change from ILoanBase<IDebt>
    {
        decimal Rate { get; set; }
    }
    public class Loan : ILoan
    {
        public static decimal DefaultRate=0.18m;
        public Loan()
        {
            this.Debts=new List<Debt>();  // change from List<IDebt>
            this.Rate=DefaultRate;
        }
        public List<Debt> Debts { get; set; } // Change from List<IDebt>
        public decimal Rate { get; set; }
        public void AddDebt(int id, decimal amount)
        {
            Debts.Add(new Debt() { ID=id, Amount=amount });
        }
    }
