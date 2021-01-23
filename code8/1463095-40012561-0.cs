    private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            string arg = File.ReadAllText(@"Resources\arguments.txt");
            ProcessStartInfo startInfo = new ProcessStartInfo(string.Concat("RustClient.exe"));
            startInfo.Arguments = arg;
            startInfo.UseShellExecute = false;
            System.Diagnostics.Process.Start(startInfo);
        }
