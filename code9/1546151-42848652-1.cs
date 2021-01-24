    public async void doWebViewPrint(string URL)
        {
            if (await vm.printCheck())
            {
                PrintDocumentAdapter adapter;
                if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.Lollipop)
                    adapter = webView.CreatePrintDocumentAdapter("test");
                else
                    adapter = webView.CreatePrintDocumentAdapter();
                var printMgr = (PrintManager)GetSystemService(PrintService);
                printMgr.Print("printTest", adapter, null);
            }
        }
