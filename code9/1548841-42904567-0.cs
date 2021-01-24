    public partial interface IMyCuteInterface_WITHEnumerable<T> : IMyCuteInterface<T> where T : IEnumerable
    {
        void DoSomethingOnlyPossibleIfGenericIsIEnumerable();
    }
    public partial interface IMyCuteInterface<T>
    {
        void DoSomeStuff();
        void DoSomeStuff2();
    }
