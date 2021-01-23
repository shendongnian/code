    foreach (XmlNode dosya in dosyalar.SelectNodes("dosya"))
        {
            string dosyaadi = dosya.SelectSingleNode("dosyaadi").InnerText;
            if (File.Exists(yerelklasor + "/" + dosyaadi)==false)
            {
                WebClient indir = new WebClient();
                Uri yol = new Uri(dosya.SelectSingleNode("url").InnerText);
                indir.DownloadFileAsync(yol, (yerelklasor + "/" + dosyaadi));
                indir.DownloadFileCompleted += new AsyncCompletedEventHandler(indir_indirmetamamlandi);
                indir.DownloadProgressChanged += new DownloadProgressChangedEventHandler(indir_indirmedurumu);
            }
        }
        foreach (XmlNode dosya in dosyalar.SelectNodes("dosya"))
        {
            string dosyaadi = dosya.SelectSingleNode("dosyaadi").InnerText;
            SifreCevir = sifreleme.MD5sifrele(yerelklasor + "/" + dosyaadi);
            if(SifreCevir != (dosya.SelectSingleNode("md5").InnerText))
            {
                label1.Text = "Güncellenen dosya: " + dosyaadi;
                WebClient indir = new WebClient();
                Uri yol = new Uri(dosya.SelectSingleNode("url").InnerText);
                indir.DownloadFileAsync(yol, (yerelklasor + "/" + dosyaadi));
                indir.DownloadFileCompleted += new AsyncCompletedEventHandler(indir_indirmetamamlandi);
                indir.DownloadProgressChanged += new DownloadProgressChangedEventHandler(indir_indirmedurumu);
            }
        }
        
        System.Diagnostics.Process baslat = new System.Diagnostics.Process();
        baslat.StartInfo.FileName = oyunexe;
        baslat.Start();
    
            
