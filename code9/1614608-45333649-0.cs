    static void Main(string[] args)
            {
                string str = "ç²¾é¸ç å¯¶ä½?å?/é»?ké??";    
                byte[] origBytes = new byte[str.Length];
                int i = 0;
                foreach (char c in str)
                {
                    origBytes[i++] = (byte)c;
                }
                Encoding origEncoding = Encoding.GetEncoding(936);
                Encoding newEncoding = Encoding.Unicode;
                byte[] newBytes = Encoding.Convert(origEncoding, newEncoding, origBytes);
                string res = newEncoding.GetString(newBytes);
            }
