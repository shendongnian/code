    public partial class Foo
    {
      public void Bar()
      {
        // ...
        this.RunTask(task);
      }
      partial void RunTask(Task task);
    }
