    public class Foo
    {
        public int id {get;set;}
        public int name {get;set;}
    }
    
    public HttpResponseMessage Post([FromBody] Foo foo) 
    {
        //some stuff...
    }
