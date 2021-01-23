    public partial class Foo
    {
      partial RunTask(Task task)
      {
        Task.Factory.StartNew(task);
      }
    }
