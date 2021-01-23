    List<B> BList = new List<B>();
    BList = new List<B>() { new B() { prop1 = "1", prop2 = "2", prop3 = "3", prop4 = "4" } };
    var serializedChildList = JsonConvert.SerializeObject(BList);
    List<A> AList = JsonConvert.DeserializeObject<List<A>>(serializedChildList);
    DataContractSerializer ser = new DataContractSerializer(typeof(List<A>));
    FileStream fs = new FileStream(@"C:\temp\AResult.xml", FileMode.Create);
    using (fs)
    {
        ser.WriteObject(fs, AList);
    }
