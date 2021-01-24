     public static async Task<Tuple<List<Student>, string, int>> StudentSearch( string text, string continuationToken = null)
            {
                var results = new List<Student>();
                FeedOptions options = new FeedOptions
                {
                    MaxItemCount = 20
                };
                if (!string.IsNullOrEmpty(continuationToken))
                {
                    options.RequestContinuation = continuationToken;
                }
                var userQuery = _client.CreateDocumentQuery<Student>(
           _uriStudentCollection, feedOptions).Where(x => x.StudentName.ToLower().Contains(text) || x.Description.ToLower().Contains(text)).OrderBy(x => x.Rank.TotalScore).AsDocumentQuery();
                var feedResponse = await userQuery.ExecuteNextAsync<Student>();
                foreach (var ad in feedResponse.AsEnumerable())
                {
                   results.Add(ad);
                }
                string continuation = feedResponse.ResponseContinuation;
                return new Tuple<List<Student>, string, int>(results, continuation, results.Count);
             }
 
