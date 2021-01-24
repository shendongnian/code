    public class DataPoint
    {
        public DataPoint(Enum mAction)
        {
            if (mAction is Enums.StringAction)
            {
                DoSomeWorkWithStringAction((Enums.StringAction)mAction);
            }
            else if (mAction is Enums.IntegerAction)
            {
                DoSomeWorkWithIntegerAction((Enums.IntegerAction)mAction);
            }
        }
        private void DoSomeWorkWithIntegerAction(Enums.IntegerAction actionToTake)
        {
            Console.WriteLine($"Enum was an IntegerAction, with action: {actionToTake}");
        }
        private void DoSomeWorkWithStringAction(Enums.StringAction actionToTake)
        {
            Console.WriteLine($"Enum was a StringAction, with action: {actionToTake}");
        }
    }
