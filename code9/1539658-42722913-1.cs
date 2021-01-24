	public class Account
	{
		public string CheckNumber { get; set; }
		public string BankAccount { get; set; }
		public string Description { get; set; }
		public int CheckAmount { get; set; }
		public DateTime ClearedDate { get; set; }
		public DateTime SentDate { get; set; }
		public bool Matches(AccountQuery query)
		{
			return (!string.IsNullOrEmpty(query.CheckNumber) && query.CheckNumber == CheckNumber) ||
				   (!string.IsNullOrEmpty(query.BankAccount) && query.BankAccount == BankAccount) ||
				   (!string.IsNullOrEmpty(query.Description) && query.Description == Description) ||
				   (query.ClearedDate.HasValue && query.ClearedDate == ClearedDate) ||
				   (query.SentDate.HasValue && query.SentDate == SentDate) ||
				   (query.CheckAmount.HasValue && query.CheckAmount == CheckAmount);
		}
	}
