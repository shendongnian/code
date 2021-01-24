    [ComVisible(true)]
    public interface ITestFactory {
        ITest Create(string arg);
    }
    
    [ComVisible(true)]
    public class TestFactory {
        public ITest Create(string arg) {
            return new Test(arg);
        }
    }
    
    [ComVisible(true)]
    public interface ITest {
         // etc...
    }
    
    internal class Test {
        private string needed;
        public Test(string arg) {
            needed = arg;
        }
        // ITest methods ...
    }
