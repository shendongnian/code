    public partial class Foo
    {
      public void Bar()
      {
        // ...
        this.RunTask(task);
      }
      private partial void RunTask(Task task);
    }
