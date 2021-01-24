    [DataContract]
    class Base
    {
        [OnDeserialized]
        //cannot be virtual
        protected void OnDeserializedBase()
        {
            //base deserialization
        }
    }
    [DataContract]
    public class Derived : Base
    {
        [OnDeserialized]
        //cannot be virtual
        OnDeserializedDerived()
        {
            //Derived deserialization
        }
    }
    Base b = new DataContractJsonSerializer(typeof(Derived)).ReadObject(stream);
