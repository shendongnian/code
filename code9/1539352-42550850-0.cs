    public class BaseTest {
        public decimal? testProp { get; set; }
    }
    public class Test : BaseTest {        
        public decimal? TestProp { get; set; } // also fails
    }
