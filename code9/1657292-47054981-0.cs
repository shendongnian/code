    public static void SetState(this ProgressBar pBar, int state)
    {
        pBar.Invoke((MethodInvoker)delegate {
            SendMessage(pBar.Handle, 1040, (IntPtr)state, IntPtr.Zero);
        });        
    }
