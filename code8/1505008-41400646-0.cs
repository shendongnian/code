    class Program {
        static void Main() {
            CancellationToken ct;
            Test("msg"); // will suggest to pass CancellationToken here
        }
        private static void Test(string msg) {
        }
        private static void Test(string msg, CancellationToken ct) {
        }
    }
