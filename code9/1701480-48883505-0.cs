    public void TestMethod(dynamic details)
    {
       string det = null;
       var convertible = details as IConvertible;
       if(convertible != null)
       {
           det = (string)Convert.ToType(details,typeof(string))
       } 
       else if(details != null)
       {
           // not so good since you have to relay on implementation...
           det = details.ToString(); 
       }
       
       if(!string.IsNullOrEmpty(det))
       {
           // the rest of the code goes here...
       }
    }
