    public class QrCodeScanPage : ZXingScannerPage
    {
        View _content;
        public QrCodeScanPage()
        {
            InitScanner();
        }
        void InitScanner()
        {
            IsAnalyzing = true;
            IsScanning = true;
            DefaultOverlayTopText = "Align the barcode within the frame";
            DefaultOverlayBottomText = string.Empty;
            OnScanResult += ScanPage_OnScanResult;
            Title = "Scan Code";
            var item = new ToolbarItem
            {
                Text = "Cancel",
                Command = new Command(async () =>
                {
                    IsScanning = false;
                    await Navigation.PopAsync();
                })
            };
            if (Device.RuntimePlatform != Device.iOS)
                item.IconImageSource = "toolbar_close.png";
            ToolbarItems.Add(item);
        }
        void ScanPage_OnScanResult(ZXing.Result result)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                IsScanning = false;
                IsAnalyzing = false;
                await Navigation.PushAsync(new QrCodeScanResultPage());
            });
        }
        protected override void OnAppearing()
        {
            IsScanning = true;
            IsAnalyzing = true;
            base.OnAppearing();
            if (Content != null)
            {
                _content = Content;
            }
            if (Content == null)
            {
                Content = _content;
            }
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            Content = null;
        }
    }
