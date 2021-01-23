        /// <summary>
        /// Writes the barcode data to a specified location
        /// </summary>
        /// <param name="data">Byte data of barcode</param>
        /// <param name="Location">Location to save barcode</param>
        public void Write(byte[] data, string location)
        {
            //Define the barcode builder with properties
            BarCodeBuilder builder = new BarCodeBuilder()
            {
                SymbologyType = Symbology.Pdf417,
                Rows = 30
            };
            //Set Data
            builder.SetBinaryCodeText(data);
            
            //Generate Barcode
            var barcodeBitmap = builder.GenerateBarCodeImage();
            //Save it to disk
            barcodeBitmap.Save(location);
        }                    
