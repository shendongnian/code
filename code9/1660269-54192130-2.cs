	class MockBulkCopy : IBulkCopy {
		private IDBContext _context;
		public MockBulkCopyHelper(IDBContext context) {
			_context = context;
		}
		public string DestinationTableName { get; set; }
		public void CreateColumnMapping(string fromName, string toName) {
			//We don't need a column mapping for raw SQL Insert statements.
			return;
		}
		public virtual Task WriteToServerAsync(DataTable dt) {
			return Task.Run(() => {
				using (var cn = _context.GetConnection()) {
					using (var cmd = cn.CreateCommand()) {
						cmd.CommandText = $"INSERT INTO {DestinationTableName}({GetCsvColumnList(dt)}) VALUES {GetCsvValueList(dt)}";
						cmd.ExecuteNonQuery();
					}
				}
			});
		}
