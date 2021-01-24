    public class ClassA
    {
      public ClassB ObjectB;
    }
    
    public class ClassB
    {
      public ClassA ObjectA;
    }
    
    public JsonResult SomeMethod()
    {
      var objA = new ClassA();
      var objB = new ClassB();
    
      objA.ObjectB = objB;
      objB.ObjectA = objA;
      return Json(objA);
    }
