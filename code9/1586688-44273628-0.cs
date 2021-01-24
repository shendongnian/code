        private static string _hexString = null;
        public static string ByteValueToCustomEncoding(byte[] byteArray, Dictionary<string, string> dict)
        {
            var result = string.Empty;
            _hexString = Shared.IO.Convert.ByteArrayToHex(byteArray);
            while (_hexString.Length > 0)
            {
                string entry = string.Empty;
                if (_hexString.Length >= 6)
                {
                    entry = Helper(dict);
                }
                else if (_hexString.Length >= 4)
                {
                    entry = Helper(dict);
                }
                else if (_hexString.Length >= 2)
                {
                    entry = Helper(dict);
                }
                else if (_hexString.Length >= 1)
                {
                    entry = Helper(dict);
                }
                result = result + entry;
            }
            return result;
        }
        private static string Helper(Dictionary<string,string> dict)
        {
            string temp = String.Empty;
            
            for (int i = (_hexString.Length > 6) ? 6: _hexString.Length; i >= 0; i = i - 2)
            {
                if (dict.TryGetValue(_hexString.Substring(0, (i == 0) ? 1 : i), out temp))
                {
                    _hexString = _hexString.Remove(0, i);
                    return temp;
                }
            }
            _hexString = _hexString.Remove(0, 1);
            return temp;
        }
