      [Test]
      public void Hex2Pdf417()
      {
         var hexStr = "fe3009333137303130323031f9200134fe300120fc2006";
         var byteArray = Enumerable.Range(0, hexStr.Length / 2).Select(x => Convert.ToByte(hexStr.Substring(x * 2, 2), 16)).ToArray();
         var byteArrayAsString = new String(byteArray.Select(b => (char)b).ToArray());
         // encode the string as PDF417
         var writer = new BarcodeWriter
         {
            Format = BarcodeFormat.PDF_417,
            Options = new PDF417EncodingOptions
            {
               Height = 200,
               Width = 200,
               Margin = 10
            }
         };
         var bitmap = writer.Write(byteArrayAsString);
         // try to decode the PDF417
         var reader = new BarcodeReader
         {
            Options = new DecodingOptions
            {
               PossibleFormats = new List<BarcodeFormat>
               {
                  BarcodeFormat.PDF_417
               },
               PureBarcode = true
            }
         };
         var result = reader.Decode(bitmap);
         // make sure, the result is the same as the original hex
         var resultBackToBytes = result.Text.Select(c => (byte)c).ToArray();
         var resultAsHexString = String.Join("", resultBackToBytes.Select(b => b.ToString("x2")));
         Assert.That(resultAsHexString, Is.EqualTo(hexStr));
      }
