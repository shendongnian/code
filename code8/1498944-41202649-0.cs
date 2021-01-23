    public interface IDebtBase
    {
        decimal Amount { get; set; }
    }
    public interface IDebt : IDebtBase
    {
        int ID { get; set; }
    }
    public interface ILoanBase<TDebt> where TDebt : IDebtBase
    {
        List<TDebt> Debts { get; set; }
    }
    public interface ILoan : ILoanBase<IDebt>
    {
        decimal Rate { get; set; }
    }
    public class Debt : IDebt
    {
        public int ID { get; set; }
        public decimal Amount { get; set; }
    }
    public class Loan : ILoan
    {
        public static decimal DefaultRate=0.18m;
        public Loan()
        {
            this.Debts=new List<IDebt>();
            this.Rate=DefaultRate;
        }
        public List<IDebt> Debts { get; set; }
        public decimal Rate { get; set; }
        public void AddDebt(int id, decimal amount)
        {
            Debts.Add(new Debt() { ID=id, Amount=amount });
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var loan=new Loan() { Rate=0.22m };
            loan.AddDebt(1002, 5400m);
        }
    }
