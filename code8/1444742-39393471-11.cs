    public partial class Foo
    {
      partial RunTask(Task task)
      {
        Task.Run(task);
      }
    }
