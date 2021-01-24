	using System;
	namespace BankAccounts  
	{  
	   class Account  
	   {  
		   protected Account(decimal balance)  
		   { _Balance = balance; }  
		   protected decimal _Balance;
		   public decimal Balance
		   {
			   get { return _Balance; }
			   protected set { _Balance = value; }
		   }
		   public override string ToString()
		   {
			   return string.Format("Balance: {0:c}", _Balance);
		   }
	   }
	   
