    public struct DateTime : ...
    {
        ...
        public static bool operator ==(DateTime d1, DateTime d2)
        {
            return d1.InternalTicks == d2.InternalTicks;
        }
    }
