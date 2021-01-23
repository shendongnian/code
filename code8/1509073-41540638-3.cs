	public class Database
	{
		#region Constant Fields
		readonly static object _locker = new object();
		readonly SQLiteConnection _database;
		#endregion
		#region Constructors
		public Database()
		{
			_database = DependencyService.Get<ISQLite>().GetConnection();
			_database.CreateTable<DataModel>();
		}
		#endregion
		#region Methods
		public async Task<IList<DataModel>> GetAllDataAsync()
		{
			return await Task.Run(() =>
			{
				lock (_locker)
				{
					return _database.Table<DataModel>().ToList();
				}
			});
		}
		public async Task<int> SaveDataAsync(DataModel dataModel)
		{
			var isDataInDatabase = (await GetAllDataAsync()).FirstOrDefault(x => x.Equals(dataModel)) != null;
			return await Task.Run(() =>
			{
				if (isDataInDatabase)
				{
					lock (_locker)
					{
						_database.Update(dataModel);
					}
					return dataModel.ID;
				}
				lock (_locker)
				{
					return _database.Insert(dataModel);
				}
			});
		}
		#endregion
