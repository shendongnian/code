    public interface ITester {
        //tester contract    
    }
    
    public class Tester : ITester {
        public Tester(IOptions<TestOptions> options) {
            //do something with test options.
        }
    }
