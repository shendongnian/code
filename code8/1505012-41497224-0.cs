    eWebClient wc = new WebClient();
                byte[] bytes = wc.DownloadData("K://BMP//EKT173026_firmaElectronicaClte.bmp");
                MemoryStream ms = new MemoryStream(bytes);
                System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
    img.Save(strFolder + "\EKT173026_firmaElectronicaClte.bmp");
