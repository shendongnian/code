    using System.Collections.Async;
    static class Operations
    {
        public static async Task Load(params string[] urls)
        {
            await urls.ParallelForEachAsync(
                async url =>
                {
                    Node n = await Build(url);
                    await WriteToDisk(n);
                },
                maxDegreeOfParallelism: 10);
        }
    }
