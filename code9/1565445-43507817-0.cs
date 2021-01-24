    private string aStringProperty { get; set; }  
    private int aIntegerProperty { get; set; }
 
-
    SomeFunctionForList(this, new List<Expression<Func<Program, dynamic>>>{
                                                                  { m => m.aStringProperty},
                                                                  { m => m.aIntegerProperty}
                                                              });
