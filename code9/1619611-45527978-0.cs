                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                        {
                            cs.Write(input, 0, input.Length);
                            cs.Flush();
                        }
                        return ms.ToArray();
                    }
