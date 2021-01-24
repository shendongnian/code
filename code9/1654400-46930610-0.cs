        static void Main(string[] args) {
            DelayWrite("It's dangerous to go alone!");
            DelayWrite("Take this.");
            Console.ReadLine();
        }
        static void DelayWrite(string text, int charDelay = 50, bool delayNewLine = true) {
            foreach (char c in text) {
                Console.Write(c);
                System.Threading.Thread.Sleep(charDelay);
            }            
            if (delayNewLine) System.Threading.Thread.Sleep(1000);
            Console.Write(Environment.NewLine);
        }
