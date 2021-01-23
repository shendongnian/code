    public class PartyMaker
        {
           
            private bool _isProcessing;
            private readonly SemaphoreSlim _slowStuffSemaphore = new SemaphoreSlim(1, 1);
            private DateTime _something;
           
            public async Task<DateTime> ShakeItAsync()
            {
                try
                {
                    var needNewRequest = !_isProcessing;
                    await _slowStuffSemaphore.WaitAsync().ConfigureAwait(false);
                    if (!needNewRequest) return _something;
                    _isProcessing = true;
                    _something = await ShakeItSlowlyAsync().ConfigureAwait(false);
                    return _something;
                }
                finally
                {
                    _isProcessing = false;
                    _slowStuffSemaphore.Release();
                }
            }
            private async Task<DateTime> ShakeItSlowlyAsync()
            {
                await Task.Delay(TimeSpan.FromSeconds(1)).ConfigureAwait(false);
                return DateTime.UtcNow;
            }
        }
