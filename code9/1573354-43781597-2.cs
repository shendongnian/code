	public class VM:BindableBase
	{
		public VM()
		{
			SetAction = new DelegateCommand<GameAction?>(a => Action = a ?? GameAction.None);
		}
		private string _ActionText;
		public string ActionText
		{
			get { return _ActionText; }
			set { SetProperty(ref _ActionText, value); }
		}
		private bool _Running = false;
		public bool Running
		{
			get { return _Running; }
			set
			{
				if(SetProperty(ref _Running, value))
				{
					if (Running)
						StartGame();
				}
			}
		}
		public GameAction Action { get; set; }
		public DelegateCommand<GameAction?> SetAction { get; set; }
		public Task ActionThread { get; set; }
		public void StartGame()
		{
			if (ActionThread == null)
			{
				ActionThread = Task.Run((Action) GameLoop); 
			}
		}
		public async void GameLoop ()
		{
			Running = true;
			while(Running)
			{
				switch (Action)
				{
					case GameAction.MoveUp:
						ActionText += $"{DateTime.Now.ToLongTimeString()} Up";
						break;
					case GameAction.MoveDown:
						ActionText += $"{DateTime.Now.ToLongTimeString()} Down";
						break;
					case GameAction.Moveleft:
						ActionText += $"{DateTime.Now.ToLongTimeString()} Left";
						break;
					case GameAction.MoveRight:
						ActionText += $"{DateTime.Now.ToLongTimeString()} Right";
						break;
					default:
						ActionText += $"{DateTime.Now.ToLongTimeString()} No Move";
						break;
				}
				await Task.Delay(2000);//wait 2 seconds
			}
			ActionThread = null;
		}
	}
