     private string generateHash()
        {
            appearance.SetVisibleSignature(new Rectangle(500, 150, 400, 200), 1, signatureFieldName);
            appearance.SignDate = DateTime.Now;
            appearance.Reason = Reason;
            appearance.Location = Location;
            appearance.Contact = Contact;
            StringBuilder buf = new StringBuilder();
            buf.Append("Digitally signed by");
            buf.Append("\n");
            buf.Append(userName);
            buf.Append("\n");
            buf.Append("Date: " + appearance.SignDate);
            appearance.Layer2Text = buf.ToString();
            appearance.Acro6Layers = true;
            appearance.CertificationLevel = 0;
            PdfSignature dic = new PdfSignature(PdfName.ADOBE_PPKLITE, PdfName.ADBE_PKCS7_DETACHED)
            {
                Date = new PdfDate(appearance.SignDate),
                Name = userName
            };
            dic.Reason = appearance.Reason;
            dic.Location = appearance.Location;
            dic.Contact = appearance.Contact;
    
            appearance.CryptoDictionary = dic;
            Dictionary<PdfName, int> exclusionSizes = new Dictionary<PdfName, int>();
            exclusionSizes.Add(PdfName.CONTENTS, (csize * 2) + 2);
            appearance.PreClose(exclusionSizes);
    
    
            HashAlgorithm sha = new SHA256CryptoServiceProvider();
            Stream s = appearance.GetRangeStream();
            int read = 0;
            byte[] buff = new byte[0x2000];
            while ((read = s.Read(buff, 0, 0x2000)) > 0)
            {
                sha.TransformBlock(buff, 0, read, buff, 0);
            }
            sha.TransformFinalBlock(buff, 0, 0);
    
            StringBuilder hex = new StringBuilder(sha.Hash.Length * 2);
            foreach (byte b in sha.Hash)
                hex.AppendFormat("{0:x2}", b);
    
            return hex.ToString();
        }
