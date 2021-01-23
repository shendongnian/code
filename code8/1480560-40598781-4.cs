    public partial class MyData
    {
        public void Save(string file)
        {
            using (Stream stream = File.Open(file, FileMode.Create))
            {
                BinaryFormatter bin = new BinaryFormatter();
                bin.Serialize(stream, this);
            }
        }
        public static MyData Load(string file)
        {
            using (Stream stream = File.Open(file, FileMode.Open))
            {
                BinaryFormatter bin = new BinaryFormatter();
                return (MyData)bin.Deserialize(stream);
            }
        }
    }
