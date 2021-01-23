    public class ViewModel
    {
    	public List<IModel> Books { get; private set; }
    
    	public ViewModel()
    	{
    		var modelCollection = new ModelsCollection();
    		
    		for (var i = 0; i < 10; i++)
    		{
    			var testBook = new Book
    			{
    				Name = "Test Book " + i
    			};
    			testBook.Authors.Add(new Author
    			{
    				Name = "Test Author " + i
    			});
    
    			modelCollection.Add(testBook);;
    		}
    
    		Books = modelCollection.GetAll();
    	}
    }
