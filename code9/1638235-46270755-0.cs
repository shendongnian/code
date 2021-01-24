    class Account
    	{
    
    		private decimal _amount;
    		private decimal _balance;
    
    		public decimal Balance
    		{
    			get { return _balance; }
    			private set { _balance = value; }
    		}
    
    		public Account(decimal pBalance)
    		{
    			this.Balance = pBalance;
    		}
    
    		public decimal Amount
    		{
    			get { return _amount; }
    			set
    			{
    				if (value < 0)
    				{
    					throw new ArgumentException("Please enter an amount greater than 0");
    				}
    				else
    				{
    					_amount = value;
    				}
    			}
    		}
    
    		public decimal Deposit()
    		{
    			_balance = _balance + _amount;
    			return _balance;
    		}
    
    		public decimal Withdrawl()
    		{
    			if (_balance - _amount < 0)
    			{
    				throw new ArgumentException("Withdrawing " + _amount.ToString("C") + " would leave you overdrawn!");
    			}
    			_balance = _balance - _amount;
    			return _balance;
    		}
    	}
