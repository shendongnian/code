	public class Account
	{
		public decimal Balance { get; private set; }
	
		public Account(decimal balance)
		{
			this.Balance = balance;
		}
	
		public void Deposit(decimal amount)
		{
			if (amount < 0m)
			{
				throw new ArgumentException("Please enter an amount greater than 0");
			}
			this.Balance = this.Balance + amount;
		}
	
		public void Withdraw(decimal amount)
		{
			if (this.Balance - amount < 0m)
			{
				throw new ArgumentException("Withdrawing " + amount.ToString("C") + " would leave you overdrawn!");
			}
			this.Balance = this.Balance - amount;
		}
	}
