    [Guid("5ff6c41a-6e4c-4d96-8e5e-72a560715b56")]
    [ComVisible(true)]
    public interface ITestA2
    {
        string DummyString();
        int DummyInt();
        bool DummyBool(); // new method
    }
    [Guid("d5b8f4b5-d33f-4e7d-866c-ef0844216a3a")]
    [ComVisible(true)]
    [ComDefaultInterface(typeof(ITestA2))]
    public class TestA2 : TestA, ITestA2
    {
        public bool DummyBool() { return true; }
    }
