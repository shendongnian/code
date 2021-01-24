    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using NLog.Common;
    /// <summary>
    /// Abstract Target with async Task support
    /// </summary>
    public abstract class AsyncTaskTarget : Target
    {
        private readonly CancellationTokenSource _cancelTokenSource;
        private readonly Queue<AsyncLogEventInfo> _requestQueue;
        private readonly Action _taskStartNext;
        private readonly Action<Task, object> _taskCompletion;
        private Task _previousTask;
        /// <summary>
        /// Constructor
        /// </summary>
        protected AsyncTaskTarget()
        {
            _taskStartNext = TaskStartNext;
            _taskCompletion = TaskCompletion;
            _cancelTokenSource = new CancellationTokenSource();
            _requestQueue = new Queue<AsyncLogEventInfo>(10000);
        }
        /// <summary>
        /// Override this to create the actual logging task
        /// <example>
        /// Example of how to override this method, and call custom async method
        /// <code>
        /// protected override Task WriteAsyncTask(LogEventInfo logEvent, CancellationToken token)
        /// {
        ///    return CustomWriteAsync(logEvent, token);
        /// }
        /// 
        /// private async Task CustomWriteAsync(LogEventInfo logEvent, CancellationToken token)
        /// {
        ///     await MyLogMethodAsync(logEvent, token);
        /// }
        /// </code></example>
        /// </summary>
        /// <param name="logEvent">The log event.</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        protected abstract Task WriteAsyncTask(LogEventInfo logEvent, CancellationToken cancellationToken);
        /// <summary>
        /// Schedules the LogEventInfo for async writing
        /// </summary>
        /// <param name="logEvent">The log event.</param>
        protected override void Write(AsyncLogEventInfo logEvent)
        {
            if (_cancelTokenSource.IsCancellationRequested)
            {
                logEvent.Continuation(null);
                return;
            }
            this.MergeEventProperties(logEvent.LogEvent);
            this.PrecalculateVolatileLayouts(logEvent.LogEvent);
            _requestQueue.Enqueue(logEvent);
            if (_previousTask == null)
            {
                _previousTask = Task.Factory.StartNew(_taskStartNext, _cancelTokenSource.Token, TaskCreationOptions.None, TaskScheduler.Default);
            }
        }
        /// <summary>
        /// Schedules notification of when all messages has been written
        /// </summary>
        /// <param name="asyncContinuation"></param>
        protected override void FlushAsync(AsyncContinuation asyncContinuation)
        {
            if (_previousTask == null)
            {
                InternalLogger.Debug("{0} Flushing Nothing", this.Name);
                asyncContinuation(null);
            }
            else
            {
                InternalLogger.Debug("{0} Flushing {1} items", this.Name, _requestQueue.Count + 1);
                _requestQueue.Enqueue(new AsyncLogEventInfo(null, asyncContinuation));
            }
        }
        /// <summary>
        /// Closes Target by updating CancellationToken 
        /// </summary>
        protected override void CloseTarget()
        {
            _cancelTokenSource.Cancel();
            _requestQueue.Clear();
            _previousTask = null;
            base.CloseTarget();
        }
        /// <summary>
        /// Releases any managed resources
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
                _cancelTokenSource.Dispose();
        }
        private void TaskStartNext()
        {
            AsyncLogEventInfo logEvent;
            do
            {
                lock (this.SyncRoot)
                {
                    if (_requestQueue.Count == 0)
                    {
                        _previousTask = null;
                        break;
                    }
                    logEvent = _requestQueue.Dequeue();
                }
            } while (!TaskCreation(logEvent));
        }
        private bool TaskCreation(AsyncLogEventInfo logEvent)
        {
            try
            {
                if (_cancelTokenSource.IsCancellationRequested)
                {
                    logEvent.Continuation(null);
                    return false;
                }
                if (logEvent.LogEvent == null)
                {
                    InternalLogger.Debug("{0} Flush Completed", this.Name);
                    logEvent.Continuation(null);
                    return false;
                }
                var newTask = WriteAsyncTask(logEvent.LogEvent, _cancelTokenSource.Token);
                if (newTask == null)
                {
                    InternalLogger.Debug("{0} WriteAsync returned null", this.Name);
                }
                else
                {
                    lock (this.SyncRoot)
                    {
                        _previousTask = newTask;
                        _previousTask.ContinueWith(_taskCompletion, logEvent.Continuation, _cancelTokenSource.Token);
                        if (_previousTask.Status == TaskStatus.Created)
                            _previousTask.Start(TaskScheduler.Default);
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                try
                {
                    InternalLogger.Error(ex, "{0} WriteAsync failed on creation", this.Name);
                    logEvent.Continuation(ex);
                }
                catch
                {
                    // Don't wanna die
                }
            }
            return false;
        }
        private void TaskCompletion(Task completedTask, object continuation)
        {
            try
            {
                if (completedTask.IsCanceled)
                {
                    if (completedTask.Exception != null)
                        InternalLogger.Warn(completedTask.Exception, "{0} WriteAsync was cancelled", this.Name);
                    else
                        InternalLogger.Info("{0} WriteAsync was cancelled", this.Name);
                }
                else if (completedTask.Exception != null)
                {
                    InternalLogger.Warn(completedTask.Exception, "{0} WriteAsync failed on completion", this.Name);
                }
                ((AsyncContinuation)continuation)(completedTask.Exception);
            }
            finally
            {
                TaskStartNext();
            }
        }
    }
