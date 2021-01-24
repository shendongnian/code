    ZXingBarcodeImageView GenerateQR(string codeValue)
    {
        var qrCode = new ZXingBarcodeImageView
        {
            BarcodeFormat = BarcodeFormat.QR_CODE,
            BarcodeOptions = new QrCodeEncodingOptions
            {
                Height = 350,
                Width = 350
            },
            BarcodeValue = codeValue,
            VerticalOptions = LayoutOptions.CenterAndExpand,
            HorizontalOptions = LayoutOptions.CenterAndExpand
        };
        // Workaround for iOS
        qrCode.WidthRequest = 350;
        qrCode.HeightRequest = 350;
        return qrCode;
    }
