    using System.IO;
    //using Microsoft.VisualStudio.Modeling;
    using MsgPack.Serialization;
    namespace ConsoleApplicationTestCs
    {
    class Program
    {
        static void Main(string[] args)
        {
        MyClass source = new MyClass();
        source.MyCustomList.Add(1);
        source.MyCustomList.Add(null);
        var context = new SerializationContext { SerializationMethod = SerializationMethod.Map };
        
        //context.DictionarySerializationOptions.OmitNullEntry = true;
        //Create serializers
        var serializer = SerializationContext.Default.GetSerializer<MyClass>(context);
        var serializerDest = SerializationContext.Default.GetSerializer<MyClass>(context);
        Stream stream = new MemoryStream();
        serializer.Pack(stream, source);
        stream.Position = 0;
        var unpackedObject = serializerDest.Unpack(stream);
    }
        
    }
    public class MyClass
    {
        public MyClass()
        {
            MyCustomList = new List<int?>();
        }
        public List<int?> MyCustomList { get; private set; }
    }
