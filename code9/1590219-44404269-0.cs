    public class Book
    {
        public BookType BookType { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
    }
    public enum BookType
    {
        Programming,
        Networking,
        Web,
    }
    public partial class Form1 : Form
    {
        private readonly List<Book> _books = new List<Book>
        {
            new Book { Image = "programming.png", BookType = BookType.Programming, Name = "VB" },
            new Book { Image = "programming.png", BookType = BookType.Programming, Name = "Java" },
            new Book { Image = "programming.png", BookType = BookType.Programming, Name = "C#" },
            new Book { Image = "networking.png", BookType = BookType.Networking, Name = "LAN Networks" },
            new Book { Image = "networking.png", BookType = BookType.Networking, Name = "Windows Networking" },
            new Book { Image = "networking.png", BookType = BookType.Networking, Name = "More About Networking" },
            new Book { Image = "html.png", BookType = BookType.Web, Name = "Web Programming" },
            new Book { Image = "html.png", BookType = BookType.Web, Name = "Javascript" },
            new Book { Image = "html.png", BookType = BookType.Web, Name = "ASP" },
        };
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            var bookTypes = _books.GroupBy(b => b.BookType).Select(g => g.Key).ToList();
            this.cboBookTypes.DataSource = bookTypes;
        }
        private void cboBookTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            var bookType = (BookType)this.cboBookTypes.SelectedItem;
            var books = _books.Where(b => b.BookType == bookType).ToList();
            var img = books.First().Image;
            this.imgBook.Image = Image.FromFile(img);
            this.lstBooks.DataSource = books;
            this.lstBooks.DisplayMember = "Name";
        }
    }
