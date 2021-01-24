      public void TestValueSet()
      {
        var x = new ValueSet();
        // Integers are OK
        x.Add("a", 42);
        // URIs are not OK - can't be serialized
        try
        {
          x.Add("b", new Uri("http://bing.com"));
        }
        catch (Exception ex)
        {
          Debug.WriteLine("Can't serialize a URI - " + ex.Message);
        }
        // Custom classes are not OK
        var myClass = new MyClass { X = 42, Y = "hello" };
        try
        {
          x.Add("c", myClass);
        }
        catch (Exception ex)
        {
          Debug.WriteLine("Can't serialize custom class - " + ex.Message);
        }
        // Serialized classes are OK
        x.Add("d", Serialize<MyClass>(myClass));
        foreach (var kp in x)
        {
          Debug.WriteLine("{0} -> {1}", kp.Key, kp.Value);
        }
      }
      string Serialize<T>(T value)
      {
        var dcs = new DataContractSerializer(typeof(T));
        var stream = new MemoryStream();
        dcs.WriteObject(stream, value);
        stream.Position = 0;
        var buffer = new byte[stream.Length];
        stream.Read(buffer, 0, (int)stream.Length);
        return Encoding.UTF8.GetString(buffer);
      }
    }
    [DataContract]
    public class MyClass
    {
      [DataMember]
      public int X { get; set; }
      [DataMember]
      public string Y { get; set; }
    }
