        static void Main(string[] args)
        {
            //a list with a possible of duplicate
            var theList = (new int[] { 1, 2, 3, 5, 7, 8, 11, 13, 14, 13 }).OrderBy(x => x).ToList();
            var step1 = theList.Select((a, b) =>  theList.Skip(b).TakeWhile((x, y) => a == x || theList[b + y] - 1 == theList[b + y - 1]));
            var step2 = step1.GroupBy(x => x.Last())
                             .Select(x => x.SelectMany(y => y).Distinct())
                             .Select(x => x.Count() > 1 ? string.Format("{0}-{1}", x.First(), x.Last()) : x.First().ToString());
            var result = string.Format("[{0}]", string.Join(", ", step2));
        }
