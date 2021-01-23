    using System.Diagnostics;
    private void Cb_Checked(object sender, RoutedEventArgs e)
    {
        StackTrace trace = new StackTrace(true);
        StackFrame[] frames = trace.GetFrames();
    
        foreach (StackFrame frame in frames)
            if (frame.GetMethod().Name == "InvokeDelegateCore")
            {
                System.Diagnostics.Debug.WriteLine("Accessed from another Thread !");
                return;
            }
    }
