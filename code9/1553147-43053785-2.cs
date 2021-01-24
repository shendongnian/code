	public class ViewModel:BindableBase
	{
		public ViewModel()
		{
			Add = new DelegateCommand(() => Collection.Add(new ImageModel()
			{
				Text = NewText,
				Uri = new Uri(NewUri)
			}));
			Delete = new DelegateCommand<ImageModel>(item => Collection.Remove(item));
			Load = new DelegateCommand(() =>
			{
				var open = new Microsoft.Win32.OpenFileDialog();
				if (open.ShowDialog() ?? false)
				{
					var file = new FileInfo(open.FileName);
					if (file.Exists)
					{
						if (Model == null)
						{
							Model = new ImageCollectionModel();
						}
						Model.Load(file);
					}
					Cancel.Execute();
				}
			});
			Save = new DelegateCommand(() =>
			{
				var save = new Microsoft.Win32.SaveFileDialog();
				if (save.ShowDialog() ?? false)
				{
					var file = new FileInfo(save.FileName);
					if (!file.Exists)
					{
						if (Model == null)
						{
							Model = new ImageCollectionModel();
						}
						Model.Collection.Clear();
						Model.Collection.AddRange(Collection);
						Model.Save(file);
					}
				}
			});
			Cancel = new DelegateCommand(() =>
			{
				Collection.Clear();
				if (Model != null)
				{
					foreach (var item in Model.Collection)
					{
						Collection.Add(item);
					}
				}
			});
			Browse = new DelegateCommand(() =>
			{
				var open = new Microsoft.Win32.OpenFileDialog();
				if (open.ShowDialog() ?? false)
				{
					NewUri = open.FileName;
				}
			});
		}
		public ImageCollectionModel Model { get; set; }
		public ObservableCollection<ImageModel> Collection { get; } = new ObservableCollection<ImageModel>();
		private string _NewText;
		public string NewText
		{
			get { return _NewText; }
			set { SetProperty(ref _NewText, value); }
		}
		private string _NewUri;
		public string NewUri
		{
			get { return _NewUri; }
			set { SetProperty(ref _NewUri, value); }
		}
		public DelegateCommand Add { get;  }
		public DelegateCommand<ImageModel> Delete { get;  }
		public DelegateCommand Browse { get; }
		public DelegateCommand Load { get; }
		public DelegateCommand Save { get; }
		public DelegateCommand Cancel { get; }
	}
