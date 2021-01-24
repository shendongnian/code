    public abstract class BaseClass
    {
        public string TestID
        {
            get;
            set;
        }
        public string TestName
        {
            get;
            set;
        }
    }
    public class TestClass1 : BaseClass
    {
        public string OtherTest
        {
            get;
            set;
        }
        public int TestValue1
        {
            get;
            set;
        }
        public TestClass1()
        {
        }
    }
    public class TestClass2 : BaseClass
    {
        public int OtherTest
        {
            get;
            set;
        }
        public int TestValue2
        {
            get;
            set;
        }
        public TestClass2()
        {
        }
    }
