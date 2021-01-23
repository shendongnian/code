    public static void ParallelForEachTest(List<string> items)
    {
        if (items != null && items.Count > 0)
        {
            List<ManualResetEvent> mEventList = new List<ManualResetEvent>();
            for (int i = 0; i < items.Count; i++)
            {
                ManualResetEvent mEvent = new ManualResetEvent(false);
                ThreadPool.QueueUserWorkItem(
                    (state) =>
                    {
                        Tuple<string, int, ManualResetEvent> tuple =
                            (Tuple<string, int, ManualResetEvent>)state;
                        Console.WriteLine(tuple.Item1 + tuple.Item2);
                        tuple.Item3.Set();
                    },
                    Tuple.Create(items[i], i, mEvent));
                mEventList.Add(mEvent);
            }
            mEventList.ForEach(x => x.WaitOne());
        }
    }
