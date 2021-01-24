    namespace DemoWebForm
    {
        public class Book
        {
            public int Id { get; set; }
            public string Author { get; set; }
            public string Title { get; set; }
        }
    
        public partial class _Default : Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    BookGridView.DataSource = new List<Book>
                    {
                        new Book {Id = 1, Author = "One", Title = "One Hundred"},
                        new Book {Id = 2, Author = "Two", Title = "Two Hundreds"},
                        new Book {Id = 3, Author = "Three", Title = "Three Hundreds"},
                    };
                    BookGridView.DataBind();
                }
            }
    
            protected void Load_Book(object sender, CommandEventArgs e)
            {
                Response.Redirect("Book.aspx?Id=" + e.CommandArgument);
            }
        }
    }
