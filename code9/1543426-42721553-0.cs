    public static void Current_TransactionCompleted(object sender, TransactionEventArgs e)
    {
    	var originatingTransaction = sender as System.Transactions.Transaction;
    
    	lock (pendingActions)
    	{
    		for (int i = pendingActions.Count - 1; i >= 0; i--)
    		{
    			var action = pendingActions[i];
    
    			if (originatingTransaction.Equals(action.CurrentTransaction))
    			{
    				var transactionStatus = e.Transaction.TransactionInformation.Status;
    				if (transactionStatus == TransactionStatus.Committed)
    				{
    					// Later in the code, I will do stuff if CurrentTransaction is null
    					action.CurrentTransaction = null;
    				}
    				else if (transactionStatus == TransactionStatus.Aborted)
    				{
    					// if It's aborted, I will remove this action
    					pendingActions.RemoveAt(i);
    				}
    				// I will skip processing any actions that still have a Transaction with the status of "Processing"
    			}
    		}
    	}
    }
