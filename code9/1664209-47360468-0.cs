    class Program {
        delegate void Printer();
        private static void Main() {
            List<Program.Printer> printerList = new List<Program.Printer>();
            // closure object which holds captured variables
            Program.DisplayClass10 cDisplayClass10 = new Program.DisplayClass10();
            int i;
            // loop assigns field of closure object
            for (cDisplayClass10.i = 0; cDisplayClass10.i < 10; cDisplayClass10.i = i + 1) {
                // your delegate is method of closure object
                printerList.Add(new Program.Printer(cDisplayClass10.CrypticFunctionName));
                i = cDisplayClass10.i;
            }
            // here, cDisplayClass10.i is 10
            foreach (Program.Printer printer in printerList)
                printer();
            Console.ReadLine();
        }
        // class for closure object
        [CompilerGenerated]
        private sealed class DisplayClass10 {
            public int i;
            internal void CrypticFunctionName() {
                Console.WriteLine(this.i);
            }
        }
    }
