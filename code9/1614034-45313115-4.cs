    public class A {
        private readonly ISecondClass B;
        private readonly IDataClassParser parser;
        public A(ISecondClass B, IDataClassParser parser) {
            this.B = B;
            this.parser = parser;
        }
        public List<DataClass> MethodUnderTest() {
            List<string> requiredData = B.GenerateFile();
            return requiredData.Select(createNewDataClass).ToList();
        }
        private DataClass createNewDataClass(string r) {
            return parser.Parse(r);
        }
    }
