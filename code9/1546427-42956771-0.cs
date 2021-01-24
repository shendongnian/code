    public class OperatorOnFilter
    {
        Dictionary<int, Tuple<int, object[]>> Operations = new Dictionary<int, Tuple<int, object[]>>();
        List<Delegate> lstOperations = new List<Delegate>();
        public OperatorOnFilter() { }
        public void AddOrReplace(int numTraitement, Delegate Action, params object[] Arguments)
        {
            if (!lstOperations.Contains(Action))
                lstOperations.Add(Action);
            if (Operations.ContainsKey(numTraitement))
                Operations[numTraitement] = new Tuple<int, object[]>(lstOperations.IndexOf(Action), Arguments);
            else
                Operations.Add(numTraitement, new Tuple<int, object[]>(lstOperations.IndexOf(Action), Arguments));
        }
        public void ApplyOperations(FilterManager Filter)
        {
            for (int i = 0; i < Filter.Values.Count(); i++)
                if (Operations.ContainsKey(i) && Filter.Values[i])
                    lstOperations[Operations[i].First].DynamicInvoke(Operations[i].Second);
        }
    }
    public class FilterManager
    {
        public bool[] Values;
        public FilterManager(int filtre)
        {
            List<bool> tmpList = new List<bool>();
            int i = 0;
            while (filtre >> i > 0)
            {
                tmpList.Add((filtre & (1 << i)) == (1 << i));
                i++;
            }
            Values = tmpList.ToArray();
        }
    }
    public class Tuple<T1, T2>
    {
        public T1 First { get; private set; }
        public T2 Second { get; private set; }
        internal Tuple(T1 first, T2 second)
        {
            First = first;
            Second = second;
        }
    }
    public static class Tuple
    {
        public static Tuple<T1, T2> New<T1, T2>(T1 first, T2 second)
        {
            var tuple = new Tuple<T1, T2>(first, second);
            return tuple;
        }
    }
