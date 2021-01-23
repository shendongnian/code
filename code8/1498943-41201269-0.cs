    public class Loan : ILoan
	{
	 List<IDebtBase> ILoanBase.Debts
		{
			get;set;
		}
	}
