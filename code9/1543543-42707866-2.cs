	internal class MyContoller : INotifyPropertyChanged
	{
		MyAdapter Adpt = new MyAdapter();
		public event PropertyChangedEventHandler PropertyChanged;
		private int rowsInserted;
		public int RowsInserted 
		{
			get { return rowsInserted;}
			set 
			{
				if (rowsInserted == value)
					return;
				rowsInserted = value;
				RaisedPropertyChanged(nameof(RowsInserted));
			}
		}
		internal MyContoller()
		{ 
			//Remember to remote the event subscriptions calling:
			// Adpt.RowsInserted -= OnRowsInserted
			Adpt.RowsInserted += OnRowsInserted;
		}
		internal void DoSqlStuffNow()
		{
			object someParameter = new object();
			Adpt.ImportStuff(someParameter);
		}
		/// <summary>
		/// Raiseds the property changed.
		/// </summary>
		/// <param name="propertyName">Property name.</param>
		protected void RaisedPropertyChanged([CallerMemberNameAttribute] string propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
		/// <summary>
		/// Called when the Rows has been inserted in the <see cref="MyAdapter"/>
		/// </summary>
		/// <param name="sender">Sender</param>
		/// <param name="numberOfRows">The Number of rows in inserted</param>
		void OnRowsInserted(object sender, int numberOfRows)
		{
			//Notify the UI about objects inserted
			RowsInserted = numberOfRows;
		}
	}
