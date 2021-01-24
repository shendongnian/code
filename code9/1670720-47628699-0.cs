    int SyncFailCount = 0; 
    private bool SyncCustomers(long TenantId, DataTable dtCusomers)
    {
        bool IsSyncSuccess = false;
       
        // While there is no success do the loop
        while (!IsSyncSuccess)
        {
            try
            {
                SyncQBClient client = new SyncQBClient();
                client.SynvCustomer(TenantId, dtCusomers);
                SyncFailCount = 0;
                IsSyncSuccess = true;
            }
            catch (CommunicationException comEx) // Mohan: Exception due to Internet issue
            {
                SyncFailCount = SyncFailCount + 1;
                Thread.Sleep(300);
            }
            catch (TimeoutException TimeoutEx) // Mohan: Exception due to timeout from web service
            {
                SyncFailCount = SyncFailCount + 1;
                Thread.Sleep(300);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "CashPundit", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SyncFailCount = 0;
                break;
            }
            // If there are more than 5 Sync Fails, break the loop and return false
            if (SyncFailCount > 5)
            {
                SyncFailCount = 0;
                break;
            }   
        }
        
        return IsSyncSuccess;
    }
