    public interface IHaveADay
    {
        string day { get; }
    }
    public static void export<T>(IList<T> data) where T : IHaveADay
    {
        var test = data[1];
        var x = test.day;
    }
