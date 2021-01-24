    public BooksViewModel : MvxViewModel
    {
    	public BooksViewModel()
    	{
    		var books = new List<Book>() { new Book(1, "AAA"), new Book(2, "BBB"), new Book(3, "CCC") };
    		Books = new ObservableCollection<EntityWrap<Book>>(books.Select(x => new EntityWrap<Book>(x, async y => await DoDeleteBookCommand(y))));
    	}
    	
    	private ObservableCollection<EntityWrap<Book>> _books;
    	public ObservableCollection<EntityWrap<Book>> Books
    	{
    		get { return _books; }
    		set
    		{
    			_books = value;
    			RaisePropertyChanged(() => Books);
    		}
    	}
    	
    	private async Task DoDeleteBookCommand(Book book)
    	{
    		var bookToRemove = Books.FirstOrDefault(x => x.Entity.Id == book.Id);
    		if (bookToRemove != null)
    		{
    			//Your code...
    			Books.Remove(bookToRemove);
    		}
    	}
    }
