    void scanner_Data(object sender, Scanner.DataEventArgs e)
    {
        ScanDataCollection scanDataCollection = e.P0;
    
    if ((scanDataCollection != null) && (scanDataCollection.Result == ScannerResults.Success))
    {
        IList<ScanDataCollection.ScanData> scanData = scanDataCollection.GetScanData();
    
        foreach (ScanDataCollection.ScanData data in scanData)
        {
            displaydata(data.LabelType + " : " + data.Data);
            // Something like this
            Xamarin.Forms.MessagingCenter.Send<App> ((App)Xamarin.Forms.Application.Current, "Barcode", data.Data);
        }
    }
    
    
    }
