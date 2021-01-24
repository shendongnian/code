    private static string host(string query)
    {
        ProcessStartInfo psi = new ProcessStartInfo("host", query);
        psi.UseShellExecute = false;
        psi.RedirectStandardOutput = true;
        Process p = Process.Start(psi);
        return p.StandardOutput.ReadToEnd();
    }
