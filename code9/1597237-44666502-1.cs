    public interface IDataObject
    {
        string GetData();
    }
    public Message : IDataObject
    {
         public string Contents;
         public Message(string contents)
         {
             Contents = contents;
         }
         public string GetData()
         {
             //Convert the string to json
             return json;
         }
    }
    public MyObject : IDataObject
    {
         public string Contents;
         public string ExtraInfo;
         public MyObject(string contents, string extraInfo)
         {
             Contents = contents;
             ExtraInfo = extraInfo;
         }
         public string GetData()
         {
             //Convert the string to json (And include extraInfo)
             return json;
         }
    }
