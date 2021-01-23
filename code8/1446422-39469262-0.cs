    /// <summary>
    /// Writes the barcode data to a specified location
    /// </summary>
    /// <param name="data">Data of the barcode</param>
    /// <param name="Location">Location to save barcode</param>
    public void Write(byte[] data, string Location)
    {
        ///* Keep Automation Barcode Creator
        KeepAutomation.Barcode.Crystal.BarCode KABarcode = new KeepAutomation.Barcode.Crystal.BarCode();
        KABarcode.Symbology = KeepAutomation.Barcode.Symbology.PDF417;
        KABarcode.PDF417DataMode = KeepAutomation.Barcode.PDF417DataMode.Auto;
        KABarcode.CodeToEncode = System.Text.Encoding.ASCII.GetString(data);
        KABarcode.ImageFormat = System.Drawing.Imaging.ImageFormat.Png;
        KABarcode.generateBarcodeToImageFile(Location);
        //*/
        ///* BarcodeLib Creator
        BarcodeLib.Barcode.PDF417 barcodeLibBar = new BarcodeLib.Barcode.PDF417();
        barcodeLibBar.Data = System.Text.Encoding.ASCII.GetString(data);
        var BarLibImage = barcodeLibBar.drawBarcode();
        BarLibImage.Save(Location);
        //*/
        ///* PQScan.Barcode Creator
        PQScan.BarcodeCreator.Barcode PQScanBarcode = new PQScan.BarcodeCreator.Barcode();
        PQScanBarcode.BarType = PQScan.BarcodeCreator.BarCodeType.PDF417;
        PQScanBarcode.Data = System.Text.Encoding.ASCII.GetString(data);
        PQScanBarcode.PictureFormat = System.Drawing.Imaging.ImageFormat.Png;
        var PQScanImage = PQScanBarcode.CreateBarcode();
        PQScanImage.Save(Location);
        //*/
    }  
