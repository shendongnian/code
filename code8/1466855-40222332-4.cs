    public class SearchResult : ReactiveObject
    {
       string _displayText;
        public string DisplayText
        {
            get { return _displayText; }
            set { this.RaiseAndSetIfChanged(ref _displayText, value); }
        }
        string _IdText;
        public string IdText
        {
            get { return _IdText; }
            set { this.RaiseAndSetIfChanged(ref _IdText, value); }
        }
       ObservableAsPropertyHelper<string> _avaText;
       public string AvaText => _avaText.Value;
       ObservableAsPropertyHelper<string> _perText;
       public string PerText => _perText.Value;
       public ReactiveCommand<StatsClass> LoadStats { get; protected set; }
       public ModelTile ()
       {
          LoadStats = ReactiveCommand.CreateAsyncTask(parameter => LoadStatsImp(this.IdText));
          LoadStats.ThrownExceptions
             .SubscribeOn(RxApp.MainThreadScheduler)
             .Subscribe(ex => UserError.Throw("Couldn't load stats", ex));
          _avaText= LoadStats.Select(stats => stats.Ava).ToProperty(this, x => x.AvaText, string.Empty);
          _perText= LoadStats.Select(stats => stats.Per).ToProperty(this, x => x.PerText, string.Empty);
          this.WhenAnyValue(x => x.IdText)
             .Where(x => !String.IsNullOrWhiteSpace(x))
             .InvokeCommand(LoadStats);
       }
       public static async Task<StatsClass> LoadStatsImp(string id)
       {
          var stats = await DownloadRss(id);
          System.Diagnostics.Debug.WriteLine($"number of stats: {stats}");
          return stats;
       }
    }
