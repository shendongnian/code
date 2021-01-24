    public class TweetsListViewModel : ReactiveObject
    {
        ReactiveList<Tweet> Tweets = new ReactiveList<Tweet>();
    
        IReactiveDerivedList<TweetTileViewModel> TweetTiles;
        IReactiveDerivedList<TweetTileViewModel> VisibleTiles;
    
        public TweetsListViewModel()
        {
            TweetTiles = Tweets.CreateDerivedCollection(
                x => new TweetTileViewModel() { Model = x },
                x => true,
                (x, y) => x.CreatedAt.CompareTo(y.CreatedAt));
    
            VisibleTiles = TweetTiles.CreateDerivedCollection(
                x => x,
                x => !x.IsHidden);
        }
    }
