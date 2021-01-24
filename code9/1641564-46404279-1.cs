    public class MyDto
    {
      public string Prop1 {get;set;} = String.Empty
      public string Prop2 {get;set;} = String.Empty
    }
    MyDto x = new MyDto();
     x = context.MyTable.Where(x => x.Id == id)
                      .Select(x => new MyDto
                                   {
                                        P1 = table.Prop1
    //I don't want prop 2, for example
                                   });
