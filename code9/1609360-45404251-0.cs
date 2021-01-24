        Dictionary<string, Task> tasks = new Dictionary<string, Task>();
        Dictionary<string, Queue<IEnumerable<string>>> queues = new Dictionary<string, Queue<IEnumerable<string>>>();
        
        foreach( var line in File.ReadAllLines("file.txt"))
        {
             var parts = line.Split('-');
             foreach( var part in parts )
             {
                  var keyValues = part.Split(',');
                  if( !tasks.ContainsKey( keyValues[0] ) )
                  {
                      var queue = new Queue<IEnumerable<string>>();
                      queues[keyValues[0]] = queue;
                      queue.Enqueue(keyValues.Skip(1));
                      var task = Task.Run(() => Process(queue));
                      tasks[keyValues[0]] = task;
                  }
                  else
                  {
                      queues[keyValues[0]].Enqueue(keyValues.Skip(1));
                  }
             }
        }
