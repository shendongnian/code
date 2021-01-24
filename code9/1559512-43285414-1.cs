              doc.Add(new Paragraph("Barcode PDF417"));
            BarcodePDF417 pdf417 = new BarcodePDF417();
            String text = "Call me Ishmael. Some years ago--never mind how long "
                + "precisely --having little or no money in my purse, and nothing "
                + "particular to interest me on shore, I thought I would sail about "
                + "a little and see the watery part of the world.";
            pdf417.SetText(text);
            Image img = pdf417.GetImage();
            img.ScalePercent(50, 50 * pdf417.YHeight);
            doc.Add(img);
            doc.Add(new Paragraph("Barcode Datamatrix"));
            BarcodeDatamatrix datamatrix = new BarcodeDatamatrix();
            datamatrix.Generate(text);
            img = datamatrix.CreateImage();
            doc.Add(img);
            doc.Add(new Paragraph("Barcode QRCode"));
            BarcodeQRCode qrcode = new BarcodeQRCode("Moby Dick by Herman Melville", 1, 1, null);
            img = qrcode.GetImage();
            doc.Add(img);
