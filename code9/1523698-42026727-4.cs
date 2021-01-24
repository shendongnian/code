    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    namespace ConsoleApplication1
    {
        class Transaction
        {
            public int TransactionID;
        }
        class Comparer : IEqualityComparer<Transaction>
        {
            public bool Equals(Transaction x, Transaction y)
            {
                return x.TransactionID == y.TransactionID;
            }
            public int GetHashCode(Transaction obj)
            {
                return obj.TransactionID.GetHashCode();
            }
        }
        class Program
        {
            static void Main()
            {
                var oldList = createList(0, 1, 50000000);
                var newList = createList(0, 2, 50000000/2);
                var comparer = new Comparer();
                Stopwatch sw = new Stopwatch();
                for (int i = 0; i < 4; ++i)
                {
                    sw.Restart();
                    var missing = oldList.Except(newList, comparer);
                    Console.WriteLine(missing.Count());
                    Console.WriteLine("Linq: " + sw.Elapsed);
                    sw.Restart();
                    missing = oldList.Except(newList, comparer).AsParallel();
                    Console.WriteLine(missing.Count());
                    Console.WriteLine("Plinq: " + sw.Elapsed);
                }
            }
            static List<Transaction> createList(int startingId, int idIncrement, int count)
            {
                var result = new List<Transaction>(count);
                for (int i = 0; i < count; ++i, startingId += idIncrement)
                    result.Add(new Transaction {TransactionID = startingId});
                return result;
            }
        }
    }
