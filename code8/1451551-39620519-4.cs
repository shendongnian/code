    public class SomeObject
    {
       public int SomeProperty { get; set; } = 6;
       // ...
    }
    public class SomeOtherObject
    {
       // ..
    }
    void foo() {
        // What is the content of "a" before foo() runs?
        object a = new SomeObject();
        // Which "a" should this refer to - the one in foo() or the one in foo_bar()?
        // Also, is this a valid cast given that we haven't specified that SomeOtherObject can be cast to SomeObject?
        var b = (SomeObject)a;
        // If we run foo() again, should "b" retain the value of SetProperty or set it back to the initial value (6)?
        b.SetProperty = 10;
        
        // ...
        // Is it safe to garbage collect "a" at this point (or will foo_bar refer to it)?
    }
    void foo_bar() {
        object a = new SomeOtherObject();
        // ...
     }
