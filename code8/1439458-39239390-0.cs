    class NETJsonFormatter
    {
        public NETJsonFormatter() { }
        static bool Initialize()
        {
            NetJSON.NetJSON.IncludeFields = true;
            NetJSON.NetJSON.IncludeTypeInformation = true;
            return true;
        }
        static bool Initialized = Initialize();
        /// <summary>
        /// Serializza un oggetto in un array di byte.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        //[System.Diagnostics.DebuggerStepThrough]
        static public byte[] SerializeWithType(object obj)
        {
            return Encoding.UTF8.GetBytes(NetJSON.NetJSON.Serialize(obj.GetType(), obj));
            
        }
        /// <summary>
        /// Trasforma un array di byte nell'oggetto originario.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        //[System.Diagnostics.DebuggerStepThrough]
        static public object DeserializeWithType(Type type, byte[] obj)
        {
            return NetJSON.NetJSON.Deserialize(type, Encoding.UTF8.GetString(obj));
        }
        static public byte[] Serialize<T>(T obj)
        {
            return Encoding.UTF8.GetBytes(NetJSON.NetJSON.Serialize(obj));
        }
        /// <summary>
        /// Deserializza un array di byte nel Type desiderato.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        static public T Deserialize<T>(byte[] obj)
        {
            return NetJSON.NetJSON.Deserialize<T>(Encoding.UTF8.GetString(obj));
        }
    }
