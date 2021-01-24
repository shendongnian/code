    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class ListAttributesEqualityComparer : IEqualityComparer<ListAttributes>
    {
        public bool Equals(ListAttributes x, ListAttributes y)
        {
            if (ReferenceEquals(x, y))
                return true;
    
            if (x == null || y == null)
                return false;
    
            // You should also do null checks on aList etc, but I have left those out for brevity
            var result = x.aList.Count == y.aList.Count && x.bList.Count == y.bList.Count && x.cList.Count == y.cList.Count &&
                         x.dList.Count == y.dList.Count;
            result = result && !x.aList.Except(y.aList).Union(y.aList.Except(x.aList)).Any();
            result = result && !x.bList.Except(y.bList).Union(y.bList.Except(x.bList)).Any();
            result = result && !x.cList.Except(y.cList).Union(y.cList.Except(x.cList)).Any();
            result = result && !x.dList.Except(y.dList).Union(y.dList.Except(x.dList)).Any();
            return result;
        }
    
        public int GetHashCode(ListAttributes obj)
        {
            return obj?.aList?.Distinct()?.Count() ?? 0;
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<SpecialClass>();
    
            // Populate list here
    
            var results = list.GroupBy(g => g.attributes, new ListAttributesEqualityComparer());
    
            Console.ReadLine();
        }
    }
    
    public class SpecialClass
    {
        public int property1;
        public ListAttributes attributes = new ListAttributes();
    }
    
    public class ListAttributes
    {
        public List<int> aList = new List<int>();
        public List<string> bList = new List<string>();
        public List<double> cList = new List<double>();
        public List<DateTime> dList = new List<DateTime>();
    }
