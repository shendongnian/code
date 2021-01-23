    [Serializable]
    public class Message_v2 //: IMessage
    {
        public Message_v2()
        {
            this.Options = new List<string>();
            this.Arguments = new Dictionary<string, object>();
            this.ValuesForNETJson = new Dictionary<string, byte[]>();
            this.TypesForNETJson = new Dictionary<string, Type>();
        }
        public bool IsEmpty { get; set; }
        public MessageCommand Command { get; set; }
        public List<string> Options { get; set; }
        /// <summary>
        /// Gli Arguments del parser sono sempre KeyValue. Qual'ora mancasse il Value viene inserito null.
        /// </summary>
        public Dictionary<string, object> Arguments { get; set; }
        /// <summary>
        /// Serializzo gli Arguments in byte array.  
        /// string - Key di Arguments[n]
        /// byte[] - contenuto serializzato di Arguments[n]
        /// </summary>
        public IDictionary<string, byte[]> ValuesForNETJson { get; set; }
        public IDictionary<string, Type> TypesForNETJson { get; set; }
        /*
         * Public methods
         */
        public void AddOptions(params string[] options)
        {
            foreach (string option in options)
                this.Options.Add(option);
        }
        public void AddArgument(string key, object value)
        {
            this.Arguments.Add(key, value);
            this.ValuesForNETJson.Add(key, NETJsonFormatter.SerializeWithType(value));
            this.TypesForNETJson.Add(key, value.GetType());
        }
        public byte[] ToArray()
        {
            //this.Arguments.ToDictionary(x => x.Value == null);
            return NETJsonFormatter.Serialize(this);
        }
        /*
         * Conversions
         */
        
        public static explicit operator Message_v2(byte[] source)
        {
            try
            {
                Message_v2 message = NETJsonFormatter.Deserialize<Message_v2>(source);
                int count = message.ValuesForNETJson.Count;
                for (int i = 0; i < count; i++)
                {
                    string key = message.Arguments.ElementAt(i).Key;
                    Type type = message.TypesForNETJson.ElementAt(i).Value;
                    byte[] value = message.ValuesForNETJson[key];
                    message.Arguments[key] = NETJsonFormatter.DeserializeWithType(type, value);
                }
                return message;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
