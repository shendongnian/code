    [ScriptMethod(ResponseFormat = ResponseFormat.Xml)]
    public Employee[] GetEmlpoyees() {
       Employee emps = new Employee[]{
          new Employee ()
          {
             // data...
          }
       };
       return emps;
    }
