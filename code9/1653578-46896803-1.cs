    string publicKey = "a383a2916281721498ff28226f851613bab6f89eb0536e9f237e158596d3b012e5707eba9f2a2963faca63fcb10f5de79caf246c1f587ee6e8f895fd848f2da5aba9d71af4dd8d06e99ff3729631626ed3f3202e56962957c0110a99d2b3893feb148291e09b54fe7df121751fb8bb589576542321b4f548be06b9845ebc6bbef1427741c00b632c05854146b597fdef5a89ace1556a769c5eaff8fc0589e7ad4adb2e2a929969c77f395b2f5a276a9389d1f43c061c9459a65b77bcd581c107aa8424223a0b44ee52582362cc96b90eea071a0dda5e9cb8fd5c9fd4ac86e177c07d79071788cb08231240dc1c9169af2629ecec31751069f0c7ccc1c1752303";
                string exponant = "010001";
                string toEncrypt = "Test123";
                using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
                {
                    RSAParameters rsap = new RSAParameters
                    {
                        Modulus = HexStringToByteArray(publicKey),
                        Exponent = HexStringToByteArray(exponant)
                    };
                    //Tried with and without the whole base64 thing
                    rsa.ImportParameters(rsap);
                    byte[] encryptedData = rsa.Encrypt(Encoding.UTF8.GetBytes(toEncrypt), false);
                    string base64Encrypted = Convert.ToBase64String(encryptedData);
