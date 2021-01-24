    public class ArticlesViewModel
    {
        public ObservableCollection<MyArticles> ArticlesList { get; private set; }
        public ArticlesViewModel()
        {
            ArticlesList = ObservableCollection<MyArticles>(ArticlesController.SelectAll());
        }
    }
