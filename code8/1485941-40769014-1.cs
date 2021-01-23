     public static string MergeArray(params IList<int>[] items)
        {
            var maxL = items.ToList().Max(x => x.Count);
            var result = new List<int>();
            for (var i = 0; i < maxL; i++)
                result.AddRange(from rowList in items where rowList.Count > i select rowList[i]);
            return string.Join(",", result);
        }
.
            var a = new List<int>() { 1, 2, 3, 4, 5 };
            var b = new List<int>() { 6, 7, 8 };
            var c = new List<int>() { 9, 10, 11, 12, 0, 2, 1 };
            var r = MergeArray(a, b, c);
