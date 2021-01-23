    private void Foo_WorkCompleted(object sender, WorkCompletedEventArgs e)
    {
        if (!Dispatcher.CheckAccess())
        {
            Dispatcher.BeginInvoke(
            (EventHandler<WorkCompletedEventArgs>)Foo_WorkCompleted, sender, e);
            return;
        }
        SomeMethod();
    }
