            Stream s = null;
            BinaryFormatter b = new BinaryFormatter();
            Binder CB = new Binder();
            b.Binder = CB;
            try
            {
                s = File.Open(fileName, FileMode.OpenOrCreate);
                //to serialize
                b.Serialize(s, yourObject);
                // to deserialize
                yourObject = (YourClass)b.Deserialize(s);
            }
            catch
            {
            }
            finally
            {
                s.Close();
            }
        [Serializable]
        public class YourClass : System.Runtime.Serialization.ISerializable
        {
           //Explicit serialization function
           public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
           {
              info.AddValue("stringVar", stringVar); 
              // and so forth...
           }
           // Deserialization
           public YourClass(SerializationInfo info, StreamingContext ctxt)
           {
              stringvar = (string)info.GetValue("stringVar", typeof(string));
              // and so forth
           }
        }
        // the serialization binder
        public class Binder : SerializationBinder
        {
           public override Type BindToType(string assemblyName, string typeName)
           {
                return System.Type.GetType(typeName); // Get it from this 
                //assembly
           }
       }
