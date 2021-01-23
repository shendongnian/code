    public class ArticleRepository : IArticleRepository
    {
        // IDbCommander is a Drapper construct
        private readonly IDbCommander _commander;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ArticleRepository"/> class, 
        /// injecting an instance of the IDbCommander using your IoC framework of 
        /// choice. 
        /// </summary>
        public ArticleRepository(IDbCommander commander)
        {
            _commander = commander;
        }
        /// <summary>
        /// Retrieves all article instances. 
        /// </summary>
        public IEnumerable<Article> RetrieveAll()
        {
            // pass the query method a reference to a 
            // mapping function (Func<T1, T2, TResult>) 
             
            // although you *could* pass the predicate 
            // in right here, the code is more readable
            // when it's separated out. 
            return _commander.Query(Map.AuthorToArticle);            
        }
        
        private static class Map
        {
            // simple mapping function which allows you
            // to map out exactly what you want, exactly
            // how you want it. no hoop jumping!
            internal static Func<Article, Author, Article> 
                AuthorToArticle = (article, author) =>
            {
                article.Author = author;
                return article;
            };
        }
    }
