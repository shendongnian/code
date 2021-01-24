    [HttpGet]
    [Route("api/mycontroller")]
    public HttpResponseMessage Get1(string p1, string p2= "blend", string p3 = "blend")
    //Call this api/mycontroller?p1=valueOne&p2=valueTwo&p3=valueThree
    
    [HttpGet]
    [Route("api/mycontroller/{p1}/p2/p3")]
    public HttpResponseMessage Get2(string p1,string p2= "blend", string p3 = "blend")
    //Call this api/mycontroller/valueOne/valueTwo/valueThree
