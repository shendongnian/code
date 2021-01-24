    public void TestMethod(dynamic details)
    { 
        if(details != null)
        {
          string det = details.ToString();
          if(string.IsNullOrEmpty(det)) { }
        }
    }
