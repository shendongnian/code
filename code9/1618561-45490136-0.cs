        private App _my_application;
		protected override void OnCreate (Bundle savedInstanceState)
		{
            // .... various things....
			global::Xamarin.Forms.Forms.Init (this, savedInstanceState);
			_my_application = new App ();
			LoadApplication (my_application);
		}
    void scanner_Data(object sender, Scanner.DataEventArgs e)
    {
        ScanDataCollection scanDataCollection = e.P0;
        if ((scanDataCollection != null) && (scanDataCollection.Result == ScannerResults.Success))
        {
            IList <ScanDataCollection.ScanData> scanData = scanDataCollection.GetScanData();
            foreach (ScanDataCollection.ScanData data in scanData)
            {
                MessagingCenter.Send<App, string> (my_application, "ScanBarcode", data.Data);
            }
        }
    }
