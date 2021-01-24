        private ObservableCollection<Article> articleList;
        public ObservableCollection<Article> ArticleList
        {
            get { return articleList; }
            set
            {
                articleList = value;
                //INPC method here
            }
        }
        private string searchParameter;
        public string SearchParameter
        {
            get
            {
                return searchParameter;
            }
            set
            {
                searchParameter = value;
                //Filter Logic for ArticalList ItemSource goes here
                //INPC method here
            }
        }
