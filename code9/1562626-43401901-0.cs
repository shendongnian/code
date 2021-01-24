     <StackPanel>
            <ListBox ItemsSource="{Binding Books}" x:Name="ListBoxBooks" DisplayMemberPath="Title"></ListBox>
            <TextBox Text="{Binding ElementName=ListBoxBooks,Path=SelectedItem.Content}"></TextBox>
        </StackPanel>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new BookViewModel();
        }
    }
    public class BookViewModel
    {
        public List<BookModel> Books { get; set; }
        public BookViewModel()
        {
            Books = new List<BookModel>()
            {
                new BookModel() {Title = "Title 1", Content = "Content 1"},
                new BookModel() {Title = "Title 2", Content = "Content 2"},
                new BookModel() {Title = "Title 3", Content = "Content 3"},
                new BookModel() {Title = "Title 4", Content = "Content 4"},
                new BookModel() {Title = "Title 5", Content = "Content 5"},
                new BookModel() {Title = "Title 6", Content = "Content 6"},
                new BookModel() {Title = "Title 7", Content = "Content 6"},
            };
        }
    }
    public class BookModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }
