    public static T CreateFrobbable<T>()
        where T: IFrobbable, new()
    {
        return new T();
    }
    public static T CreateFrobabbleOnSteroids<T>()
        where T: IFrobbableOnSteroids, new()
        {
            return new T();
        }
