    class Program
    {
        static void Main(string[] args)
        {
            Container C = new Container();
            Container CopyC = DeepClone(C);
        }
        public static T DeepClone<T>(T obj)
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, obj); //<-- error here
                ms.Position = 0;
                return (T)formatter.Deserialize(ms);
            }
        }
    }
    [Serializable]
    public class Container
    {
        public ObjectType AnObject;
        public Container()
        {
            AnObject = new ObjectType
            {
                R = new Random()
            };
        }
    }
    [Serializable]
    public class ObjectType : ISerializable
    {
       
        internal Random R;
        public ObjectType() { }
        protected ObjectType(SerializationInfo info, StreamingContext context)
        {
            R = info.GetString("Random").DeserializeRandom();
            
        }       
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            
            info.AddValue("Random",R.SerializeRandom());          
        }
        
    }
    public static class RandomExtensions
    {
        public static string SerializeRandom(this Random random)
        {
            var binaryFormatter = new BinaryFormatter();
            var arr = random.GetType().GetField("_seedArray", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            using (var temp = new MemoryStream())
            {
                binaryFormatter.Serialize(temp, arr.GetValue(random));
                return Encoding.BigEndianUnicode.GetString(temp.ToArray());
            }
        }
        public static Random DeserializeRandom(this string randomStr)
        {
            Random r = new Random();
            var binaryFormatter = new BinaryFormatter();
            using (var temp = new MemoryStream(Encoding.BigEndianUnicode.GetBytes(randomStr)))
            {
                var arr = (int[])binaryFormatter.Deserialize(temp);
                r.GetType().GetField("_seedArray", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).SetValue(r, arr);
                return r;
            }
           
        }
       
    }
    
