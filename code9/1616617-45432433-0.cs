      [Test]
      public void Test_Binary_Data_Encoding_As_Char()
      {
         var writer = new BarcodeWriter
         {
            Format = BarcodeFormat.QR_CODE,
            Options = new QrCodeEncodingOptions
            {
               ErrorCorrection = ErrorCorrectionLevel.L,
               CharacterSet = "ISO-8859-1"
            }
         };
         // Generate dummy binary data
         var binaryData = new byte[256];
         for (var i = 0; i < binaryData.Length; i++)
            binaryData[i] = (byte)i;
         // Convert the dummy binary data to a string
         var binaryDataAsChar = new char[binaryData.Length];
         for (var i = 0; i < binaryDataAsChar.Length; i++)
            binaryDataAsChar[i] = (char)binaryData[i];
         var binaryDataAsString = new String(binaryDataAsChar);
         // encode the string as QR code
         var qrcode = writer.Write(binaryDataAsString);
         // decode the QR code (full roundtrip test)
         var reader = new BarcodeReader();
         var binaryDataAsStringFromQrCode = reader.Decode(qrcode);
         var binaryDataAsStringFromQrCodeText = binaryDataAsStringFromQrCode.Text;
         // a little hack, because the barcode reader converts the \n to \r\n
         binaryDataAsStringFromQrCodeText = binaryDataAsStringFromQrCodeText.Remove(10, 1);
         
         // convert the result string to the byte array
         var binaryDataFromQrCode = new byte[256];
         for (var i = 0; i < binaryDataFromQrCode.Length; i++)
            binaryDataFromQrCode[i] = (byte)binaryDataAsStringFromQrCodeText[i];
         // Assert, that the representation of the result string and the byte array is equal to the source
         Assert.That(binaryDataAsString, Is.EqualTo(binaryDataAsStringFromQrCodeText));
         for (var i = 0; i < binaryData.Length; i++)
            Assert.That(binaryDataFromQrCode[i], Is.EqualTo(binaryData[i]), "position " + i + " is wrong");
      }
