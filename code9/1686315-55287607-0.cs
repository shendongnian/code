            using (TransactionScope scope = new TransactionScope())
            {
                using (YourContext context = new YourContext())
                {
                    //DB operations
                    context.SaveChanges();
                }
                Transaction.Current.TransactionCompleted += Current_TransactionCompleted;
                TransactionInformation info = Transaction.Current.TransactionInformation;
                string transactionId = Guid.Empty.Equals(info.DistributedIdentifier) ? info.LocalIdentifier : info.DistributedIdentifier.ToString();
                scope.Complete();
            }
            //For the transaction completed event:
            private void Current_TransactionCompleted(object sender, TransactionEventArgs e)
            {
                 //e.Transaction.TransactionInformation contains the Id
            }
