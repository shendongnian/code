    #if __ANDROID__
                var vRenderer = Xamarin.Forms.Platform.Android.Platform.GetRenderer(webview);
                var viewGroup = vRenderer.ViewGroup;
    
                for (int i = 0; i < viewGroup.ChildCount; i++)
                {
                    if (viewGroup.GetChildAt(i).GetType().Name == "WebView")
                    {
                        var AndroidWebView = viewGroup.GetChildAt(i) as Android.Webkit.WebView;
                        var tmp = AndroidWebView.CreatePrintDocumentAdapter("print");
                        var printMgr = (Android.Print.PrintManager)Forms.Context.GetSystemService(Android.Content.Context.PrintService);
                        printMgr.Print("print", tmp, null);
                        break;
                    }
                }
    #elif __IOS__
                var printInfo = UIKit.UIPrintInfo.PrintInfo;
                printInfo.Duplex = UIKit.UIPrintInfoDuplex.LongEdge;
                printInfo.OutputType = UIKit.UIPrintInfoOutputType.General;
                printInfo.JobName = "AppPrint";
                var printer = UIKit.UIPrintInteractionController.SharedPrintController;
                printer.PrintInfo = printInfo;
                printer.PrintingItem = Foundation.NSData.FromFile(pdfPath);
                printer.ShowsPageRange = true;
                printer.Present(true, (handler, completed, err) =>
                {
                    if (!completed && err != null)
                    {
                        System.Diagnostics.Debug.WriteLine("Printer Error");
                    }
                });
    #endif
