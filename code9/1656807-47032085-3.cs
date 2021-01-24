	public class Bar :BindableBase
	{
		public Bar()
		{
			Bouncer = new Bouncer() { Bar = this };
		}
		private bool _IsOpen;
		public bool IsOpen
		{
			get => _IsOpen;
			set => SetProperty(ref _IsOpen, value);
		}
		public Bouncer Bouncer { get;  }
		public ObservableCollection<string> Message { get; } = new ObservableCollection<string>();
		public ObservableCollection<Patron> Guests { get; } = new ObservableCollection<Patron>();
	}
	public class Bouncer
	{
		public Bouncer()
		{
			AllowGuestAccess = new DelegateCommand(() =>
			{
				var patron = new Patron();
				Bar.Guests.Add(patron);
				Bar.Message.Insert(0, $"{patron.Name} has been admitted");
			});
		}
		public Bar Bar { get; set; }
		public DelegateCommand AllowGuestAccess { get; }
	}
	public class Patron
	{
		public static Random Rnd { get; } = new Random();
		public static List<string> Names { get; } = new List<string>();
		public Patron()
		{
			Name = Names[Rnd.Next(Names.Count)];
		}
		public string Name { get; }
	}
