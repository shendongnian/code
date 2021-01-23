     public string  Encode (string EncodingText,int NumberOfTimesYouWantToEncode)
        {
            byte[] data;
            string base64_text = EncodingText;
            for (int i = 0; i < NumberOfTimesYouWantToEncode; i++)
            {
                data = Encoding.ASCII.GetBytes(base64_text);
                base64_text = Convert.ToBase64String(data);
          
            }
            return base64_text;
        }
        public string Decode(string EncodingText, int NumberOfTimesYouNeedToDecode)
        {
            byte[] data;
            string decodedString = EncodingText;
            for (int i = 0; i < NumberOfTimesYouNeedToDecode; i++)
            {
                data = Convert.FromBase64String(decodedString);
                decodedString = Encoding.ASCII.GetString(data);
            }
            return decodedString;
        }
