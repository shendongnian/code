    public sealed class MainService
    {
        /// <summary>
        /// The main method which is called.
        /// </summary>
        public void Execute()
        {
            try
            {
                // somehow get the userid/sessionid, you don't say where these are from
                var userId = "?";
                var sessionId = "?"
                searchService.ExecuteSearchAsync(userId, sessionId).Wait();
            }
            catch (Exception e)
            {
                // gets additional info (userId, sessionId) from the thread context
                StaticLoggerClass.LogError(e);
            }
        }
    }
    public sealed class SearchService
    {
        private IRepository  repository = new Repository();
        public async Task ExecuteSearchAsync(string userId, string sessionId)
        {
            try
            {
                var result = await this.GetResultsAsync();
            }
            catch (Exception e)
            {
                // gets additional info (userId, sessionId) from the thread context
                StaticLoggerClass.LogError($"userId={userId}; sessionId={sessionId}; error={e}");
            }
        }
        // ........ 
        private async Task<ResultModel> GetResultsAsync()
        {
            var result = this.repository.GetAsync();
        }
    }
