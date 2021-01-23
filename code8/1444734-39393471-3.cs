    public partial class Foo
    {
      private partial RunTask(Task task)
      {
        Task.Run(task);
      }
    }
