    public static string Base64Encode(string plainText)
    {
    
                //check plain text string and pad if needed
                int mod4 = plainText.Length % 4;
                if (mod4 > 0)
                {
                    plainText += new string('=', 4 - mod4);
                }
    
                //convert to base64 and return
                var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
                return System.Convert.ToBase64String(plainTextBytes);
            }
    
            public static string Base64Decode(string base64EncodedData)
            {         
                //decode base64 and return as string
                var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
                return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
            }
