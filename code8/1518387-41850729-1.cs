    class MessageSerializer
    {
        public Message Deserialize(string str)
        {
            Message message = new Message();
            int index = 0;
            message.Protocol = DeserializeProperty(str, ref index, 2, Convert.ToInt32);
            message.Type = DeserializeProperty(str, ref index, 1, Convert.ToString);
            message.Measurement = DeserializeProperty(str, ref index, 4, Convert.ToString);
            message.DateTime = DeserializeProperty<DateTime>(str, ref index, 16, (s) =>
            {
                // Parse date time from 2013120310:28:55 format
                return DateTime.ParseExact(s, "yyyyMMddhh:mm:ss", CultureInfo.CurrentCulture);
            });
            //...
            return message;
        }
    
        static T DeserializeProperty<T>(string str, ref int index, int count, 
            Func<string, T> converter)
        {
            T property = converter(str.Substring(index, count));
            index += count;
            return property;
        }
    }
