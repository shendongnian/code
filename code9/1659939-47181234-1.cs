    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    
    public class BlockingQueue<T>: IDisposable
    {
    
        /// <summary>   The queue based on a list, to extract from position and remove at position. </summary>
        private readonly List<QueueObject<T>> queue = new List<QueueObject<T>>();
        private bool _closing;
    
    
        private class QueueObject<T>
        {
            //// <summary>   Constructor. </summary>
            /// <param name="timeStamp">    The time stamp when the object is enqueued. </param>
            /// <param name="queuedObject"> The queued object. </param>
            public QueueObject(DateTime timeStamp, T queuedObject)
            {
                TimeStamp = timeStamp;
                QueuedObject = queuedObject;
            }
    
            /// <summary>   Gets or sets the queued object. </summary>
            /// <value> The queued object. </value>
            public T QueuedObject { get; private set; }
    
            /// <summary>   Gets or sets timestamp, when the object was enqueued. </summary>
            /// <value> The time stamp. </value>
            public DateTime TimeStamp { get; private set; }
        }
    
    
        public void Enqueue(T item)
        {
            lock (queue)
            {
                // Add an object with current time to the queue
                queue.Add(new QueueObject<T>(DateTime.Now, item));
    
    
                if (queue.Count >= 1)
                {
                    // wake up any blocked dequeue
                    Monitor.PulseAll(queue);
                }
            }
        }
    
        /// <summary>   Try dequeue an object that matches the passed expression. </summary>
        /// <param name="expression">   The expression that an object has to match. </param>
        /// <param name="value">        [out] The resulting object. </param>
        /// <param name="waitTimeInMs"> (Optional)  The time in ms to wait for the item to be returned. </param>
        /// <returns>   An object that matches the passed expression. </returns>
        public bool TryDequeueWhere(Func<T, bool> expression, out T value, int? waitTimeInMs = null)
        {
            // Save the current time to later calculate a new timeout, if an object is enqueued and does not match the expression.
            DateTime dequeueTime = DateTime.Now;
            lock (queue)
            {
                while (!_closing)
                {
                    if (waitTimeInMs == null)
                    {
                        while (queue.Count == 0)
                        {
                            if (_closing)
                            {
                                value = default(T);
                                return false;
                            }
                            Monitor.Wait(queue);
                        }
                    }
                    else
                    {
                        // Releases the lock on queue and blocks the current thread until it reacquires the lock. 
                        // If the specified time-out interval elapses, the thread enters the ready queue.
                        if (!Monitor.Wait(queue, waitTimeInMs.Value))
                        {
                            break;
                        }
                        try
                        {
                            // select the object by the passed expression
                            var queuedObjects = queue.Select(q => q.QueuedObject).ToList();
                            // Convert the expression to a predicate to get the index of the item
                            Predicate<T> pred = expression.Invoke;
                            int indexOfQueuedObject = queuedObjects.FindIndex(pred);
                            // if item is found, get it and remove it from the list
                            if (indexOfQueuedObject >= 0)
                            {
                                value = queuedObjects.FirstOrDefault(expression);
                                queue.RemoveAt(indexOfQueuedObject);
                                return true;
                            }
                        }
                        catch (Exception)
                        {
                            break;
                        }
                        // If item was not found, calculate the remaining time and try again if time is not elapsed.
                        var elapsedTime = (DateTime.Now - dequeueTime).TotalMilliseconds;
                        if ((int) elapsedTime >= waitTimeInMs.Value)
                        {
                            break;
                        }
                        waitTimeInMs = waitTimeInMs.Value - (int) elapsedTime;
                    }
                }
            }
            value = default(T);
            return false;
        }
    
        /// <summary> Close the queue and let finish all waiting threads. </summary>
        public void Close()
        {
            lock (queue)
            {
                _closing = true;
                Monitor.PulseAll(queue);
            }
        }
    
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged
        /// resources.
        /// </summary>
        public void Dispose()
        {
            Close();
        }
    
    }
