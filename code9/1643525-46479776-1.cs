    class Account
    {
    
    	enum ActionType
    	{
    		Withdraw,
    		Deposit,
    	}
    
    	private void WriteAction(ActionType action)
    	{
    		StreamWriter outputFile;
    		outputFile = File.AppendText("account.log");
    
    		outputFile.WriteLine("{0},{1}", DateTime.Now, action);
    		outputFile.Close();
    	}
    }
