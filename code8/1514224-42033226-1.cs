      [WebMethod]
    public void Decrypt(object sender, EventArgs e)
    {
        string folderPath = "path";
        DirectoryInfo d = new DirectoryInfo(folderPath).GetDirectories().OrderByDescending(ds => ds.LastWriteTimeUtc).First();
        try
        {
            foreach (FileInfo file in d.GetFiles())
            {
                string plaintext = "";
                string filename = file.Name;
                byte[] cipherText = new byte[file.Length];
                FileStream fs = file.OpenRead();
                fs.Read(cipherText, 0, (int)file.Length);
                byte[] keybytes = Encoding.UTF8.GetBytes("7061737323313233");
                byte[] iv = Encoding.UTF8.GetBytes("7061737323313233");
                MyWebService.MyWebServicedts = new MyWebService.MyWebService();
                using (var rijAlg = new RijndaelManaged())
                {
                    rijAlg.Mode = CipherMode.CBC;
                    rijAlg.Padding = PaddingMode.PKCS7;
                    rijAlg.FeedbackSize = 128;
                    rijAlg.Key = keybytes;
                    rijAlg.IV = iv;
                    var decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);
                    using (var msDecrypt = new MemoryStream(cipherText))
                    {
                        using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (var srDecrypt = new StreamReader(csDecrypt))
                            {
                                plaintext = srDecrypt.ReadToEnd();
                            }
                        }
                    }
                }
                plaintext = plaintext.Substring(23);
                string name = filename.Substring(filename.LastIndexOf("/") + 1);
                name = name.Replace(".encrypted", "");
                dts.FileUpload(folderPath, plaintext, name);
            }
        }
        catch (Exception ex)
        {
            string err = ex.Message;
        }
    }
