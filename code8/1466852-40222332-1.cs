    public class ModelTile : ReactiveObject
    {
       public string _Id;
       public string Id
       {
           get { return _Id; } 
           set { this.RaiseAndSetIfChanged(ref _Id, value); }
       }
       public string _Displayname;
       public string Displayname 
       { 
           get { return _Displayname; }
           set { this.RaiseAndSetIfChanged(ref _Displayname, value); }
       }
       public string _Updated;
       public string Updated 
       { 
           get { return _Updated; }
           set { this.RaiseAndSetIfChanged(ref _Updated, value); }
       }
       public bool _New;
       public bool New 
       { 
           get { return _New; }
           set { this.RaiseAndSetIfChanged(ref _New, value); }
       }
       ObservableAsPropertyHelper<string> _ava;
       public string Ava => _ava.Value;
       ObservableAsPropertyHelper<string> _per;
       public string Per => _per.Value;
       public ReactiveCommand<StatsClass> LoadStats { get; protected set; }
       public ModelTile ()
       {
          LoadStats = ReactiveCommand.CreateAsyncTask(parameter => LoadStatsImp(this.ID));
          LoadStats.ThrownExceptions
             .SubscribeOn(RxApp.MainThreadScheduler)
             .Subscribe(ex => UserError.Throw("Couldn't load stats", ex));
          _ava = LoadStats.Select(stats => stats.Ava).ToProperty(this, x => x.Ava, string.Empty);
          _per = LoadStats.Select(stats => stats.Per).ToProperty(this, x => x.Per, string.Empty);
          this.WhenAnyValue(x => x.Id)
             .Where(x => x > 0)
             .InvokeCommand(LoadStats);
       }
       public static async Task<StatsClass> LoadStatsImp(string id)
       {
          var stats = await DownloadRss(id);
          System.Diagnostics.Debug.WriteLine($"number of stats: {stats}");
          return stats;
       }
    }
