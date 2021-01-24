        public async void LoadData()
        {
            string result = null;
            for ( i = 0; i <= 10; i++ )
            {
                try
                {
                    var cst = new CancellationTokenSource( TimeSpan.FromSeconds( 3 ) ); 
                    result = await Task.Run( (Func<string>) LongRunningMethodCall, cst.Token );
                    if ( !cst.IsCancellationRequested )
                        break;
                }
                catch ( Exception ex )
                {
                }
            }
        }
