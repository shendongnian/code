    Public void DownloadPDF()
    {
           Utility.AddNetworkConnection();
            var webClient = new WebClient();
            loadingView = new LoadingView();
            loadingView.Show("Downloading PDF");
            webClient.DownloadDataCompleted += (s, e) =>
            {
                Utility.RemoveNetworkConnection();
                File.WriteAllBytes(_pdfPathLocation, e.Result); // writes to local storage
                InvokeOnMainThread(() =>
                {
                    loadingView.Hide();
                    _pdfImageElement.SetValueAndUpdate("Open PDF");
                    var a = new UIAlertView("Done", "File downloaded and saved", null, "OK", "Open PDF");
                    a.Show();
                    a.Clicked += OpenPdf;
                });
            };
            var url = new Uri(_wreck.PdfURL);
            webClient.Encoding = Encoding.UTF8;
            webClient.DownloadDataAsync(url);
    }
