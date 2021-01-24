    public class Dialog
    {
        private static WaitForm WaitBox;
    
        public static void UpdateMessage(string Message)
        {
            if (WaitBox != null && WaitBox.IsHandleCreated && !WaitBox.IsDisposed && !WaitBox.IsDisposing)
            {
                WaitBox.Invoke(new Action(() =>{ WaitBox.UpdateMessage(Message); });
            }
        }
    }
