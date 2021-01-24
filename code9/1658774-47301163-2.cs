    namespace MyProject
    {
    	[ImplementPropertyChanged]
    	public class BuggyViewModel : MvxViewModel
    	{
    		private Random _random;
    
    		string  _BuggyTitle { get; set; }
    
    		public string BuggyTitle
    		{
    			get { return _BuggyTitle; }
    			set { _BuggyTitle = value; RaisePropertyChanged(() => BuggyTitle); }
    		}
    
    		public BuggyViewModel()
    		{
    			_random = new Random();
    		}
    
    		public override void Start()
    		{
    			base.Start();
    			BuggyTitle = "" + _random.Next(1000);
    		}
    	}
    }
