        string urlOut = HttpUtility.UrlEncode(Base64Encode("Pfx32q+xLq4R+VocXy4IC8aQNdmFqdA284THap54Bl4="));
        string urlIn = Base64Decode(HttpUtility.UrlDecode(urlOut));
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }
        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
            return Encoding.UTF8.GetString(base64EncodedBytes);
        }
