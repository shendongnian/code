    public void Method()
    {
        System.Threading.Thread.Sleep(500); // do something
        pgbStatus.Dispatcher.Invoke(() => pgbStatus.Value += 10);
        System.Threading.Thread.Sleep(500); // do something
        pgbStatus.Dispatcher.Invoke(() => pgbStatus.Value += 10);
        System.Threading.Thread.Sleep(500); // do something
        pgbStatus.Dispatcher.Invoke(() => pgbStatus.Value += 60);
        System.Threading.Thread.Sleep(500); // do something
        pgbStatus.Dispatcher.Invoke(() => pgbStatus.Value += 10);
        System.Threading.Thread.Sleep(500); // do something
        pgbStatus.Dispatcher.Invoke(() => pgbStatus.Value += 10);
    }
