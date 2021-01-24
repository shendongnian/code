    using ProtoBuf;
    using System.Collections.Generic;
    
    static class P
    {
        static void Main()
        {
            var obj = new MyType { FuturesCurveData = {
                    { 1.0, (1, 2, 3, 4, 5, 6, 7, 8) },
                    { 2.0, (2, 3, 4, 5, 6, 7, 8, 9) },
                } };
            var clone = Serializer.DeepClone(obj);
            foreach(var pair in clone.FuturesCurveData)
            {
                System.Console.WriteLine($"{pair.Key}: {pair.Value}");
            }
        }
    }
    [ProtoContract]
    class MyType
    {
        [ProtoMember(1)]
        public SortedDictionary<double, (double Bid, double Ask, double Open, double High, double Low, double Close, int Volume, int OpenInt)> FuturesCurveData { get; } =
        new SortedDictionary<double, (double Bid, double Ask, double Open, double High, double Low, double Close, int Volume, int OpenInt)>();
    }
