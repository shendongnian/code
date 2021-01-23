    public abstract class Base1
    {
        public abstract void Method1();
    }
    public abstract class BaseBoth : Base1
    {
        public abstract void Method2();
    }
    public class JustOne : Base1
    {
        // only implement Method1 here
    }
    public class Both : BaseBoth
    {
        // implement both here
    }
