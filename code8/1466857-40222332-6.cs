    ObservableAsPropertyHelper<ObservableCollection<SearchResult>> _searchResults;
    public ObservableCollection<SearchResult> SearchResults => _searchResults;
    
    public ReactiveCommand<ObservableCollection<SearchResult>> Search { get; protected set; }
    public TheClassTheseAreIn 
    {       
       Search = ReactiveCommand.CreateAsyncTask(parameter => SearchImp(this.SearchCriteria));
       _searchResults = Search.ToProperty(this, x => x.SearchResults, new ObservableCollection<SearchResult>);
    }
    
