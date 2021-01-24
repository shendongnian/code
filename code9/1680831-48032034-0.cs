      private void EngageAutoRenewLock(BrokeredMessage message, CancellationTokenSource renewLockCancellationTokenSource)
            {
                var renewalThread = Task.Factory.StartNew(() =>
                {
                    Trace(string.Format("Starting lock renewal thread for MsgID {0}", message.MessageId));
    
                    while (!renewLockCancellationTokenSource.IsCancellationRequested)
                    {
                        // we use Sleep instead of Task.Delay to avoid get an exception when token is cancelled
                        System.Threading.Thread.Sleep(30000); 
                        // check again after sleeping
                        if (!renewLockCancellationTokenSource.IsCancellationRequested)
                        {
                            try
                            {
                                // renewlock wraps a RenewLockAsync() call
                                message.RenewLock();
                            }
                            catch (Exception ex)
                            {
                                /* Do Nothing. 
                         
                                    This exception can happen due the async nature of the RenewLock Operation (async Begin/End), it is possible we 
                                    completed/abandoned/deadlettered the message in the main thread in the middle of the RenewLock operation. 
                         
                                    Additionally, we should keep retrying to renew lock until renewLockCancellationTokenSource has ben signaled. 
                                    This will allow to handle other transient renewal issues. */
                                
                                Trace(string.Format("Lock renewal failed due an exception for MsgID {0} - {1}", message.MessageId, ex.Message));
                            }
                            Trace(string.Format("Lock renewed MsgID {0}", message.MessageId));
                        }
                        else
                        {
                            Trace(string.Format("Lock renewed MsgID {0} not happened due IsCancellationRequested == true", message.MessageId));
                        }
                    }
                    Trace(string.Format("Lock renewal has been cancelled by cancellationToken (ok) for MsgID {0}", message.MessageId));
                }, renewLockCancellationTokenSource.Token);
            }
