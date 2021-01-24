        public class TestClone : ICloneable
        {
            public bool IsSuccess { get; set; }
            public string ErrorCode { get; set; }
            public string ErrorDetail { get; set; }
            public object Clone()
            {
                return this.MemberwiseClone();
            }
        }
        static void Main(string[] args)
        {
            var test1 = new TestClone() { IsSuccess = true, ErrorCode = "0", ErrorDetail = "DTL1" };
            var test2 = (TestClone) test1.Clone();
            test2.ErrorDetail = "DTL2";
        }
