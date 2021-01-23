        public static async Task<TResult> WaitAsync<TResult>(this TaskCompletionSource<TResult> tcs, CancellationToken cancelToken)
        {
            void CancelTcs()
            {
                if( tcs.Task.IsCompleted )
                    return;
                if( tcs.Task.IsFaulted )
                    return;
                if( !tcs.Task.IsCanceled )
                    tcs.TrySetCanceled();
            }
            using( var linkedTokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancelToken) )
            using( linkedTokenSource.Token.Register(CancelTcs) ) {
                    await tcs.Task;
            }
            return tcs.Task.Result;
        }
