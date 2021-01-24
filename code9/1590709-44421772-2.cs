    public class BadCommand
    {
        private readonly string privateField1;
        private string privateField2;
        public BadCommand(string field1)
        {
            privateField1 = field1;
            privateField2 = "testingbadCommand";
        }
    }
