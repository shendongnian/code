        public void LoadData()
        {
            string result = null;
            for ( i = 0; i <= 10; i++ )
            {
                try
                {
                    var cst = new CancellationTokenSource( TimeSpan.FromSeconds( 3 ) );
                    var task = Task.Run( () => LongRunningMethodCall( cst.Token ), cst.Token );
                    var result = task.Result;
                }
                catch ( AggregateException ex )
                {
                    // Check that all exceptions is a OperationCanceledException
                    if ( !ex.InnerExceptions.All( e => e is OperationCanceledException ) )
                        throw ex;
                }
            }
        }
