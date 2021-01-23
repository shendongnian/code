    Public class ClassName  // "Public" needs to be lowercase
    {
       public ClassName(){}
       public string Name {get; set;}
       public SomeOtherClass class {get; set;}  // "class" is a reserved word and
                                                // can't be used as a property name.
                                                // You're probably getting a squiggly here.
    }
    public class SomeOtherClass ()  // A class declaration doesn't end in parentheses
                                    // This will give you some more squigglys.
    {
       public int StatusId {get; set;}
       public string StatusDesc { get; set;}
    }
