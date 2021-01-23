            const int MaxSearchEntriesToReturn = 100;
            string searchTerm = "twitter";
            // oldest id you already have for this search term
            ulong sinceID = 1;
            // used after the first query to track current session
            ulong maxID; 
            var combinedSearchResults = new List<Status>();
            List<Status> searchResponse =
                await
                (from search in twitterCtx.Search
                 where search.Type == SearchType.Search &&
                       search.Query == searchTerm &&
                       search.Count == MaxSearchEntriesToReturn &&
                       search.SinceID == sinceID
                 select search.Statuses)
                .SingleOrDefaultAsync();
            combinedSearchResults.AddRange(searchResponse);
            ulong previousMaxID = ulong.MaxValue;
            do
            {
                // one less than the newest id you've just queried
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
            } while (searchResponse.Any());
            combinedSearchResults.ForEach(tweet =>
                Console.WriteLine(
                    "\n  User: {0} ({1})\n  Tweet: {2}",
                    tweet.User.ScreenNameResponse,
                    tweet.User.UserIDResponse,
                    tweet.Text));
        }
I wrote a blog post a while back to explain generally how this works:
    [Working with Timelines with LINQ to Twitter][1]
It's a little old and doesn't include the async syntax, but does explain the `SinceID`, `MaxID`, and techniques. Twitter also has good documentation, explaining the how and why of their paging strategy:
    [Working with Timelines (Twitter)][1]
With that said, the Twitter API does limit how far back you can go with searches. In [The Search API, Best Practices][1] section, they describe that they only go back 6 to 9 days.
  [1]: https://dev.twitter.com/rest/public/search
