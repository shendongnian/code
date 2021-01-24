     using (var bulkCopy = new SqlBulkCopy(connStr))
    {
         bulkCopy.NotifyAfter = x; // after how many rows of copy do you want a notif event
         bulkCopy.SqlRowsCopied += (sender, eventArgs) =>
     		                       {
     	                             if (someLogic) // some condition to abort     	                                    {      
                                             eventArgs.Abort = true;
     	                                    }                                        
     	                            };                                           
    }
