    public class SecondClassWrapper : ISecondClass {
        private SecondClass B = new SecondClass();
        public List<string> GenerateFile() {
            return B.GenerateFile();
        }
    }
