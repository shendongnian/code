    public interface ILoanBase<TDebt> : ILoanBase
        where TDebt : IDebtBase
    {
        List<TDebt> Debts { get; set; }
    }
    public class Loan : ILoan
    {
        ...
        public IList<IDebtBase> GetDebts()
        {
            return Debts.OfType<IDebtBase>().ToList();
        }
    }
