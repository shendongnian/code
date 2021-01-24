    private readonly List<QueueObject<T>> queue = new List<QueueObject<T>>();
    private IDictionary<string, Func<T, bool>> _expressionList = new
    Dictionary<string, Func<T, bool>>();
    public void Enqueue(T item)
          {
             lock (queue)
             {
                queue.Add(new QueueObject<T>(DateTime.Now, item));
    
                if (_queueSize != null && _queueSize.Value > 0)
                {
                   while (queue.Count > _queueSize)
                   {
                      queue.RemoveAt(0);
                   }
                }
                lock (_expressionList)
                {
                   foreach (var expression in _expressionList)
                   {
                      if (queue.Select(q => q.QueuedObject).Where(expression.Value).Any())
                      {
                         lock (expression.Value)
                         {
                            Monitor.PulseAll(expression.Value);   
                         }
                      }
                   }
                }
                if (queue.Count == 1)
                {
                   // wake up any blocked dequeue
                   Monitor.PulseAll(queue);
                }
             }
          }
          public bool TryDequeueWhere(Func<T, bool> expression, out T value, int? waitTimeInMs = null)
          {
             lock (_expressionList)
             {
                if (_expressionList.ContainsKey(expression.ToString()))
                {
                   value = default(T);
                   return false;
                }
             }
             try
             {
                lock (_expressionList)
                {
                   _expressionList.Add(expression.ToString(), expression);
                }
                lock (expression)
                {
                   if (waitTimeInMs != null)
                   {
                      if (!Monitor.Wait(expression, waitTimeInMs.Value))
                      {
                         value = default(T);
                         return false;
                      }
                   }
                   else
                   {
                      Monitor.Wait(expression);
                   }
    
                   try
                   {
                      lock (queue)
                      {
                         var queuedObjects = queue.Select(q => q.QueuedObject).ToList();
                         Predicate<T> pred = expression.Invoke;
                         int indexOfQueuedObject = queuedObjects.FindIndex(pred);
                         if (indexOfQueuedObject >= 0)
                         {
                            value = queuedObjects.FirstOrDefault(expression);
                            queue.RemoveAt(indexOfQueuedObject);
                            return true;
                         }
                      }
                   }
                   catch (Exception)
                   {
                      value = default(T);
                      return false;
                   }
                }
             }
             catch (Exception ex)
             {
                
             }
             finally
             {
                lock (_expressionList)
                {
                   _expressionList.Remove(expression.ToString());
                }
             }
             value = default(T);
             return false;
          }
