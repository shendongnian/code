    private void callSwapDNS(string NIC, string DNS)
    {
        const int ERROR_CANCELLED = 1223; //The operation was canceled by the user.
        ProcessStartInfo info = new ProcessStartInfo(@"swap.exe");
        string wrapped = string.Format(@"""{0}"" ""{1}""", NIC, DNS);
        info.Arguments = wrapped;
        info.UseShellExecute = true;
        info.Verb = "runas";
        info.WindowStyle = ProcessWindowStyle.Hidden;
        try
        {
            Process.Start(info);
            Thread.Sleep(500);
        }
        catch (Win32Exception ex)
        {
            if (ex.NativeErrorCode == ERROR_CANCELLED)
                MessageBox.Show("Why you no select Yes?");
            else
                throw;
        }
    }
