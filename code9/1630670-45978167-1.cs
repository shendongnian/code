            static async Task<List<Tweet>> DoPagedSearchAsync(TwitterContext twitterCtx, Acquirer formx)
            {
            formx.Enabled = false;
            int MaxSearchEntriesToReturn = 50; //number of results per loop (int)
            int MaxTotalResults = 250; //total number of results (int)
            formx.progressBar1.Maximum = MaxTotalResults;
            string searchTerm = "String to search";
            ulong sinceID = 1;
            ulong maxID;
            List<Status> combinedSearchResults = new List<Status>();
            List<Status> searchResponse =
                await
                (from search in twitterCtx.Search
                 where search.Type == SearchType.Search &&
                       search.Query == searchTerm &&
                       search.Count == MaxSearchEntriesToReturn &&
                       search.SinceID == sinceID
                 select search.Statuses)
                .SingleOrDefaultAsync();
            if (searchResponse != null)
            {
                combinedSearchResults.AddRange(searchResponse);
                ulong previousMaxID = ulong.MaxValue;
                do
                {
                    maxID = searchResponse.Min(status => status.StatusID) - 1;
                    Debug.Assert(maxID < previousMaxID);
                    previousMaxID = maxID;
                    searchResponse =
                        await
                        (from search in twitterCtx.Search
                         where search.Type == SearchType.Search &&
                               search.Query == searchTerm &&
                               search.Count == MaxSearchEntriesToReturn &&
                               search.MaxID == maxID &&
                               search.SinceID == sinceID
                         select search.Statuses)
                        .SingleOrDefaultAsync();
                    combinedSearchResults.AddRange(searchResponse);
                    try
                    {
                        formx.progressBar1.Value = combinedSearchResults.Count;
                    }
                    catch
                    { }
                } while (searchResponse.Any() && combinedSearchResults.Count <= (MaxTotalResults - MaxSearchEntriesToReturn));
            }
            else
            {
                MessageBox.Show("No results obtained");
                formx.progressBar1.Value = 0;
                formx.Enabled = true;
                return null;
            }
            var package = parser(combinedSearchResults, formx);
            return await Task.Run(() =>
            {
                return package;
            });
        }
