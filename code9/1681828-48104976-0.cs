    nst = new TransferTest();
    
    public class TransferTest : nsITransfer
    {
      //[...]
      void nsIWebProgressListener2.OnProgressChange64(nsIWebProgress aWebProgress, nsIRequest aRequest, long aCurSelfProgress, long aMaxSelfProgress, long aCurTotalProgress, long aMaxTotalProgress)
      {
        Debug.WriteLine($"Progress: {aCurSelfProgress} / {aMaxSelfProgress}");
      }
    }
