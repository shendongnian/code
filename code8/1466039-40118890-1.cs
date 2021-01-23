    using System;
    using System.Diagnostics;
    namespace ConsoleApplication1 {
        class Program {
            static public long GetPadovanRecursive(int n) {
                if (n == 0) { return 1; }
                if (n == 1) { return 0; }
                if (n == 2) { return 0; }
                if (n == 3) { return 1; }
                return GetPadovanRecursive(n - 2) + GetPadovanRecursive(n - 3);
                }
    
            static int N_Max = 8192;
            static long[] pdvn = new long[N_Max];
    
            static public long GetPadovanQuick(int n) {
                Debug.Assert(n < N_Max);
                if (n == 0) { return 1; }
                if (n == 1) { return 0; }
                if (n == 2) { return 0; }
                if (n == 3) { return 1; }
    
                pdvn[3] = 1;
                for (int i = 4; i <= n; i++) {
                    pdvn[i] = pdvn[i - 2] + pdvn[i - 3];
                    }
                return pdvn[n];
                }
    
    
            static void Main(string[] args) {
                const int Count = 64;
                Stopwatch stp = new Stopwatch();
    
                // Sanity check
                Console.WriteLine("From https://oeis.org/A000931");
                Console.WriteLine("Ref: 1  0  0  1  0  1  1  1  2  2  3  4  5  7  9  12  16  21  28  37  49  65  86  114  151  200  265");
                Console.Write("Rec: ");
                for (int i = 0; i < 27; i++) {
                    Console.Write("{0}  ", GetPadovanRecursive(i));
                    }
                Console.WriteLine();
                Console.Write("Qik: ");
                for (var i = 0; i < 27; i++) {
                    Console.Write("{0}  ", GetPadovanQuick(i));
                    }
                Console.WriteLine();
                Console.WriteLine();
    
                long sum = 0;
                stp.Start();
                for (int i = 0; i < Count; i++) {
                    sum += GetPadovanRecursive(i);
                    }
                stp.Stop();
                Console.WriteLine("Recursive method: {0,12:F6} ms   checksum: {1}", stp.Elapsed.TotalMilliseconds, sum);
            
            sum = 0;
            stp.Restart();
            for (var i = 0; i < Count; i++) {
                sum += GetPadovanQuick(i);
                }
            Console.WriteLine("Quick     method: {0,12:F6} ms   checksum: {1}", stp.Elapsed.TotalMilliseconds, sum);
            }
        }
    }
