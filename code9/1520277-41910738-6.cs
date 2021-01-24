    interface IFoo
    {
        IFoo Frob();
    }
    interface IBar
    {
        IBar Frob();
    }
    public class Blah: IFoo, IBar
    {
        Foo IFoo.Frob() => new Foo();
        Bar IBar.Frob() => new Bar();
        void Frob();
    }
