    public class Task
    {
    }
    public class TaskViewModel : IEquatable<Task>
    {
        public bool Equals(Task other)
        {
            throw new NotImplementedException();
        }
    }
    private bool CompareTask<T>(Task model, T data)
            where T : IEquatable<Task>
        {
            return data.Equals(model);
        }
