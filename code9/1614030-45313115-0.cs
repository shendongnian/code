    public class A {
        private readonly ISecondClass B;
        public A(ISecondClass B) {
            this.B = B;
        }
        public List<DataClass> MethodUnderTest() {
            List<string> requiredData = B.GenerateFile();
            return requiredData.Select(createNewDataClass).ToList();
        }
        //TODO: This can also be refactored out into its own class/service and injected
        private DataClass createNewDataClass(string r) {
            return new DataClass {
                Property1 = r.Substring(0, 2),
                Property2 = r.Substring(3, 5),
                Property3 = r.Substring(9, 10)
            };
        }
    }
