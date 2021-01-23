    public static IEnumerable<PrintQueue> GetAllPrinterQueues()
    {
    	using (var printServer = new LocalPrintServer())
    	{
    		foreach (string printerName in PrinterSettings.InstalledPrinters.OfType<string>())
    		{
    			var match = Regex.Match(printerName, @"(?<machine>\\\\.*?)\\(?<queue>.*)");
    			yield return match.Success ?
    				new PrintServer(match.Groups["machine"].Value).GetPrintQueue(match.Groups["queue"].Value) :
    				printServer.GetPrintQueue(printerName);
    		}
    	}
    }
