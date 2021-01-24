    public static class Listener
    {
        private static List<IMyInterface> objects = new List<IMyInterface>();
        public static void Register(IMyInterface obj)
        {
            if (!objects.Contains(obj))
                objects.Add(obj);
        }
        public static void Unregister(IMyInterface obj)
        {
            if (objects.Contains(obj)
                objects.Remove(obj);
        }
        public static void DoSomethingWithObjects()
        {
            foreach (IMyInterface obj in objects)
                // do something ...
        }
    }
