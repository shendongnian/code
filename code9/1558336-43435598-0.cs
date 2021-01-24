                OdbcConnection connection = null;
            var connectionTask = Task.Factory.StartNew(() =>
            {
                connection = new OdbcConnection(connectionString);
                connection.Open();
                Thread.Sleep(3000);
            });
            connectionTask.ContinueWith((tsk) => 
            {
                if(tsk.Exception==null && tsk.IsCompleted)
                {
                    connection.DoSomething();
                }
                else
                {
                    // here you can examine exception that thrown on task
                    Console.WriteLine("Connection Timed-out");
                }
            });
