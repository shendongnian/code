    public enum MyOperator {
        Contains,
        DoesNotContain,
        GreaterThan,
        LessThan
    }
    public class TestClass {
        public TestClass(MyOperator op, Object operand) {
            this.Operator = op;
            this.Operand = operand;
        }
        public MyOperator Operator { get; set; }
        public Object Operand { get; set; }
