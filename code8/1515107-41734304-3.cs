    public void MasterMethod()
        {
            try
            {
                BeginConTrans();
                // your methods A,B,C
                //must use ExecuteNonQueryTrans for your get/put data
            }
            catch (Exception ex)
            {
                //if any method fails handle exception and rollback the transcation
                RollbackConTrans();
            }
            CommitConTrans(); // if success ,commit the transcation
        }
