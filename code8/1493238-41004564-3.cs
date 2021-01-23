    // somewhere in your code put this little model
    // this is what your JavaScript object will get bound to when you post
    public MyModel{
       // this is to match the property name on your JavaScript  object, its case sensitive i.e { 'pass': words};
       public string pass {get;set;} 
    }
    
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static string ShowMe(MyModel model)
    {
        // you can now access the properties on your MyModel like this
        string beans = model.pass + ". We repeat this is only a test.";    
        return beans;
    }
