            Encoding enc = null;
            try
            {
                enc = Encoding.GetEncoding(GetCmdCodePage());
            }
            catch (Exception)
            {
                enc = Encoding.GetEncoding(855); // the value for Cyrillic
            }
