    interface ITask<T> 
    {
        IQuestion<T> Question { get; }
        List<IAnswer<T>> Answers { get; }
    }
