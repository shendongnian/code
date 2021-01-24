    class Account
    {
    
    	enum ActionType
    	{
    		Withdraw,
    		Deposit,
    	}
        public void Withdraw()
        {
            WriteAction(ActionType.Withdraw);
        }
    
    	private void WriteAction(ActionType action)
    	{
    		StreamWriter outputFile;
    		outputFile = File.AppendText("account.log");
    
    		outputFile.WriteLine("{0},{1}", DateTime.Now, action);
    		outputFile.Close();
    	}
    }
