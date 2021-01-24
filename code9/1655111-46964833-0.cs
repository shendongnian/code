		public void LiteDB_ShowAll()
		{
			using (var dataBase = new LiteDatabase(dbConnectionString))
			{
				var collection = dataBase.GetCollection<Stranka>("stranka");
				lvStranke.Items.Clear();
				foreach(var cust in collection.FindAll().OrderByDescending(x => x.Date)) // or by x.Id
				{
					lvStranke.Items.Add(cust);
				}               
			}         
		}
