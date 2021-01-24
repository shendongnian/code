    public class ClassToSerialize
    {
        public AnotherOne anotherOne { get; set; }
        public ClassToSerialize()
        {
        }
    }
    public abstract class AnotherOne
    {
        public AnotherOne()
        {
        }
    }
    public class ContainerOne : AnotherOne
    {
        public uint placeholder = 0xdeadcafe;
    }
    //...
    public void Test()
    {
        ClassToSerialize obj = new ClassToSerialize();
        obj.anotherOne = new ContainerOne();
        //or FileStream..
        using (MemoryStream ms = new MemoryStream())
        {
            Portable.Xaml.XamlServices.Save(ms, obj);
            ms.Seek(0, SeekOrigin.Begin);
            ClassToSerialize obj2 = Portable.Xaml.XamlServices.Load(ms) as ClassToSerialize;
        }
    }
