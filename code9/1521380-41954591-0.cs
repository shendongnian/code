        static void Main(string[] args)
        {
            var articleTags = new List<ArticleTag>
            {
                new ArticleTag(1, "a"),
                new ArticleTag(1, "b"),
                new ArticleTag(1, "c"),
                new ArticleTag(2, "a"),
                new ArticleTag(2, "b"),
                new ArticleTag(3, "a"),
                new ArticleTag(4, "b"),
                new ArticleTag(4, "c"),
                new ArticleTag(5, "a"),
                new ArticleTag(5, "b"),
                new ArticleTag(5, "c"),
            };
            var resultDict = new Dictionary<int, int>(); // Where we store the result
            const int mainArticleId = 1; // Your main article
            var tagsFromMainArticle = articleTags.Where(x => x.Id == mainArticleId).Select(x => x.Tag).ToList(); // All tags on the main article
            tagsFromMainArticle.ForEach(tag => 
                articleTags
                    .Where(a => a.Tag == tag && a.Id != mainArticleId)
                    .ToList()
                    .ForEach(x =>
                    {
                        if (resultDict.ContainsKey(x.Id)) resultDict[x.Id]++;
                        else resultDict[x.Id] = 1;
                    }));
            foreach (var resultKeyValuePair in resultDict.OrderByDescending(v => v.Value).Take(3))
            {
                Console.WriteLine($"Key = {resultKeyValuePair.Key}, Value = {resultKeyValuePair.Value}");
            }
        }
