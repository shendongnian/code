     protected string Title {
     get { 
        string value;
        ApplicationViewModel._hash.TryGetValue("Title", out value);
        return value;
      }
      set {
        ApplicationViewModel._hash["Title"] = value;
      }
    }
