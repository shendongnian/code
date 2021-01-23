    public interface ILoanBase
    {
        string Issuer { get; set; }
        IList<IDebtBase> GetDebts();
    }
