    Mywebservice.Mywebservice dts = new Mywebservice.Mywebservice();
                using (var rijAlg = new RijndaelManaged())
                {
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
                plaintext = plaintext.Substring(23); //This is the part to strip. The first
				//23 chars are the mime type of the file. Remove that and just save the string data.
			    string name = filename.Replace(".encrypted", "");
                dts.FileUpload(folderPath, plaintext, name); //call the same webservice used for saving encrypted object.
            }
