    public abstract class A0
    {
        //has common code that should be implemented by all
    }
    public abstract class B0 : A0
    {
        protected SameProperty {get; set;}
    }
    public class B : B0
    {
         //Uses SameProperty with some of its own variables
    }
    public class C : B0
    {
         //Also uses SameProperty with some of ITS own variables
    }
    public class D : A0
    {
        //Does not use SameProperty. Will never use it and there will be many other classes just like this.
    }
