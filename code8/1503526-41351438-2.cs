    public class Form1 : Form
    {
        private readonly ListArticle _articles = new ListArticle();
    
        // assume strings have been added to articles by this point.
    
        // option 1 - use same ListArticle instance
        public void Foo()
        {
            var form = new Form2();
            form.Articles = _articles; 
        }
    
        // option 2 - add strings to new ListArticle
        public void Bar()
        {
            var articles = new ListArticle();
            articles.Clothes.AddRange(_articles.Clothes);
            var form = new Form2();
            form.Articles = articles;
        }
    }
    
    public class Form2 : Form
    {
        public ListArticle Articles { get; set; }
    }
