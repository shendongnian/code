    public static class BaseProcessOperator<T>
    {
        static List<string> prevProcess = new List<string>();
        static object obj = new object();
        public static void AddRange(List<string> para)
        {
            lock (obj)
            {
                prevProcess.AddRange(para);
            }
        }
        public static List<string> GetProcesses()
        {
            lock (obj)
            {
                return prevProcess;
            }
        }
        public static void Remove<TParam>(List<TParam> currList, Func<TParam, string> fn)
        {
            if (currList != null && currList.Count() > 0)
            {
                lock (obj)
                {
                    foreach (var i in currList)
                    {
                        var r = prevProcess.FirstOrDefault(s => s == fn(i));
                        if (!string.IsNullOrWhiteSpace(r))
                            prevProcess.Remove(r);
                    }
                }
            }
        }
    }
