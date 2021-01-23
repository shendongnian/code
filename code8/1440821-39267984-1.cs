    string result = string.Empty;
    using (Process process = new Process())
    {
        process.StartInfo = st; // your ProcessStartInfo
        StringBuilder resultBuilder = new StringBuilder();
        process.OutputDataReceived += (sender, e) =>
        {
            st.AppendLine(e.Data);
        };
        process.Start();
        process.BeginOutputReadLine();
        process.WaitForExit();
        result = resultBuilder.ToString();
    }
