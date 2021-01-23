	public void Delete<T>(T entity) where T : class, ITypeWithId
	{
		using (IDbConnection cn = Connection)
		{
			cn.Open();
			cn.Execute("DELETE FROM " + _tableName + " WHERE Id=@ID", new { ID = entity.Id });
		}
	}
