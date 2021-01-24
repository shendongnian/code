	internal class MyAdapter
	{
		public event EventHandler DeleteCompleted;
		public event EventHandler<int> RowsInserted;
		public event EventHandler ComplexQuerycCompleted;
		public event EventHandler<bool> OperationCompleted;
		internal void ImportStuff(object someParameter)
		{
			SqlConnection sqlConnection = new SqlConnection("connection");
			// All of this has to happen in one connection/transaction.
			// It should not be broken into multiple methods
			DeleteFromTable1();
			DeleteFromTable2();
			// Now I want to tell the user delete is complete!
			this.DeleteCompleted?.Invoke(this, new EventArgs());
			MakeTempTable();
			InsertIntoTempTable(someParameter);
			int rowCount = ImportIntoTable1();
			// Now I want to tell the user how many rows were just inserted!
			this.RowsInserted?.Invoke(this, rowCount);
			DoComplexQuery();
			DoAnotherComplexQuery();
			// Now I want to tell the user complex queries are done!
			this.ComplexQuerycCompleted.Invoke(this, new EventArgs());
			ImportIntoTable2();
			DropTempTable();
			// Presumably, I can say "success" when this function returns, which is fine
			this.OperationCompleted?.Invoke(this, true);
		}
	}
