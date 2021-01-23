    class IDObject
    {
      private string id;
      private string path;
      private string fName;
      //public properties
      public string Id
      {
        get { return id; }
        set { id = value; }
      }
   
      public string Path
      {
        get { return path; }
        set { path = value; }
      }
      public string FName
      {
        get { return fName; }
        set { fName = value; }
      }
      // constructor
      public IDObject(string inID, string inPath, string inFName)
      {
        id = inID;
        path = inPath;
        fName = inFName;
      }
