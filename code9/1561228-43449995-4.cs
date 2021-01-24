        public static void Testable<T>(this T obj, Action action)
        {
            if(obj is IFake)
            {
                action = ((IFake)obj).GetFakeAction(action);
            }
            action();
        }
