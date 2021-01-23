        static Dictionary<string, string> seq = new Dictionary<string, string>();
        public static void setCategorySeq(string lucio, string textValue)
        {
            seq[lucio] = textValue;
        }
        public static string setCategorySeq(string lucio)
        {
            if (seq.ContainsKey(lucio))
                return seq[lucio];
            return null;
        }
`
