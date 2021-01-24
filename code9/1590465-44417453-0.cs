    var barcodeWriter = new ZXing.Mobile.BarcodeWriter
	{
		Format = ZXing.BarcodeFormat.CODE_128,
		Options = new ZXing.Common.EncodingOptions
		{
			Width = 300,
			Height = 300
		}
	};
 
    var barcode = barcodeWriter.Write("ZXing.Net.Mobile");
