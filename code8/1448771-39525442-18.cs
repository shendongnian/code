    static void Main(string[] args)
    {
        var obj = new createGenericClass<IWebService, IVoiceService>();
        obj.CallDoSomeThing(new Web_Service(), 1, 2);
        obj.CallDoSomeThingElse(new Voice_Service(), 3, 4);
    }
