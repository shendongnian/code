    class Program
    {
        static void Main(string[] args)
        {
            Container C = new Container();
            Console.WriteLine(C.AnObject.R.Next());
            Container CopyC = DeepClone(C);
            Console.WriteLine(C.AnObject.R.Next());
            Console.WriteLine(CopyC.AnObject.R.Next());
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
            R = new Random();
            var binaryFormatter = new BinaryFormatter();
            using (var temp = new MemoryStream(Encoding.BigEndianUnicode.GetBytes(info.GetString("_seedArr"))))
            {
                var arr = (int[])binaryFormatter.Deserialize(temp);
                R.GetType().GetField("_seedArray", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).SetValue(R, arr);               
            }
            R.GetType().GetField("_inext", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).SetValue(R, info.GetInt32("_inext"));
            R.GetType().GetField("_inextp", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).SetValue(R, info.GetInt32("_inextp"));
        }       
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            var binaryFormatter = new BinaryFormatter();
            var arr = R.GetType().GetField("_seedArray", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            using (var temp = new MemoryStream())
            {
                binaryFormatter.Serialize(temp, arr.GetValue(R));
                info.AddValue("_seedArr", Encoding.BigEndianUnicode.GetString(temp.ToArray())); 
            }
            info.AddValue("_inext", R.GetType().GetField("_inext", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(R));
            info.AddValue("_inextp", R.GetType().GetField("_inextp", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(R));
        }
    }
