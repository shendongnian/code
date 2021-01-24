    public class ThreadFactory
    {
        ...
        public ThreadTask Continue( ThreadWorker sender )
        {
            if ( _backlog.Count > 0 )
            {
                ThreadTask task;
                do
                {
                    if ( _backlog.TryDequeue( out task ) )
                    {
                        return task;
                    }
                }
                while ( _backlog.Count > 0 );
            }
    
            _available.Push( sender );
            return null;
    
        }
    
        public void Enqueue( ThreadTask task )
        {
            if ( _available.Count > 0 )                              // If there's a worker available (and sleeping/locked), wake them and pass the new task
            {
                ThreadWorker worker;
                do
                {
                    if ( _available.TryPop( out worker ) )
                    {
                        worker.Wake( task );
                    }
                }
                while ( _available.Count > 0 );        // Busy-wait TryPop on worker stack, this should only take a couple cycles (if not one)
            }
            else                                                    // Otherwise this task will be added to the backlog queue
            {
                _backlog.Enqueue( task );
            }
        }
    }
