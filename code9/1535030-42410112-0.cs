    public interface IQuestion<out T>
    {
        T Content { get; }
    }
    public interface IAnswer<out T>
    {
        T Content { get; }
        bool IsCorrect { get; }
    }
    interface ITask<TQuestion, TAnswer> 
        where TQuestion : IQuestion<object>
        where TAnswer : IAnswer<object>
    {
        TQuestion Question { get; }
        List<TAnswer> Answers { get; }
    }
