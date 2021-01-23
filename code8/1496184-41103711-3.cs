	public class FileViewModel : INotifyPropertyChanged
	{
		private string _File;
		public string File
		{
			get { return _File; }
			set
			{
				_File = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("File"));
			}
		}
		public ObservableCollection<ItemModel> ItemCollection { get; } = new ObservableCollection<ItemModel>();
		public event PropertyChangedEventHandler PropertyChanged;
		public void ReadFile()
		{
			ItemCollection.Clear();
			using (StreamReader reader = new StreamReader(File))
			{
				var header =  reader.ReadLine();
				while(!reader.EndOfStream)
				{
					var data = reader.ReadLine();
					var item = ItemModel.Create(header, data, ',');
					ItemCollection.Add(item);
				}
			}
		}
	}
