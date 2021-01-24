    this.m_webView.ConsoleMessage += new ConsoleSignalHandler(this.ConsoleMessage);
...
    [ConnectBefore]
    private void ConsoleMessage(System.Object sender, ConsoleSignalArgs e) {
        Console.WriteLine("Console Message got Here!");
    }
