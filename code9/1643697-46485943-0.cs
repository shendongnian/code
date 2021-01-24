	public class CashDesk
	{
		public List<PersonCashier> Cashiers { get; set; }
	}
	public class PersonCashier : Person
	{
		public List<CashDesk> CashDesks { get; set; }
	}
