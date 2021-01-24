    public class MyClassRoot
    {
        public MyClass Obj1 {get;set;}
        public MyClass Obj2{get;set;}
        public MyClass Obj3{get;set;}
    }
    
    var result = JsonConvert.DeserializeObject<MyClassRoot>(json);
    var obj1Name = result.Obj1.Name;
    var obj1Id = result.Obj1.Id;
