    public interface IFoo {
        int MethodA(int a);
        void MethodB(long b);
        void MethodC(string c);
        ...
    }
    var MoqFoo = new Mock<IFoo>();
    MoqFoo.Setup(m => m.MethodA(It.Is(a => a > 0)).Returns<int>(a => a + 1);
    MoqFoo.Setup(m => m.MethodC(It.IsAny<string>()).Callback<string>(c => Debug.Write(c));
