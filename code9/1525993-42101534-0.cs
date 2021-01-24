    public byte[] ProtectPdfStreamWithPassword(
                string filePath,
                string password)
            {
                using (var outStream = new MemoryStream())
                {
                    using (var reader = new PdfReader(filePath))
                    {
                        using (var stamper = new PdfStamper(reader, outStream))
                        {
                            var passwordBytes =
                                    Encoding.ASCII.GetBytes(password);
    
                            stamper.SetEncryption(
                                passwordBytes,
                                passwordBytes,
                                PdfWriter.AllowPrinting,
                                PdfWriter.ENCRYPTION_AES_256);
                        }
                    }
    
                    return outStream.ToArray();
                }
            }
