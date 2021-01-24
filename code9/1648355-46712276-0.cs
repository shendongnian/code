     public void DoOperation(string identifier = "__DefaultBehaviour")
            {
                if (bankingOperationFunc != null)
                    bankingOperationFunc(identifier).Withdraw();
    
                Console.WriteLine("Transaction Successful ");
            }
