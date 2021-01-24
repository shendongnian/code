    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    class Program
    {
        public static int? GetItemInThePagedDataList(IEnumerable<int> list, int pageSize, int pageNumber, int rowNumber)
        {
            var index = (pageSize * pageNumber) + rowNumber;
            var nullableList = list.Select(z => (int?) z);
            return index < 0 ? null : nullableList.ElementAtOrDefault(index);
        }
    
        public static int? GetItemInThePagedDataList(IList<int> list, int pageSize, int pageNumber, int rowNumber)
        {
            var index = (pageSize * pageNumber) + rowNumber;
            return (index >= list.Count || index < 0) ? (int?)null : list.ElementAt(index);
        }
    
        static void Main(string[] args)
        {
            var list = new List<int> {1, 2, 3, 4};
            IEnumerable<int> items = list;  
    
            Console.WriteLine(GetItemInThePagedDataList(list, 2, 1, 1));
            Console.WriteLine(GetItemInThePagedDataList(items, 2, 1, 1));
            Console.WriteLine(GetItemInThePagedDataList(list, 2, 4, 1));
            Console.WriteLine(GetItemInThePagedDataList(items, 2, 4, 1));
            Console.WriteLine(GetItemInThePagedDataList(list, 2, -1, 1));
            Console.WriteLine(GetItemInThePagedDataList(items, 2, -1, 1));
        }
    }
