	[Fact]
	public virtual void Dispose_command_before_reader()
	{
		using (var connection = CreateOpenConnection())
		{
			DbDataReader reader;
			using (var command = connection.CreateCommand())
			{
				command.CommandText = "SELECT 'test';";
				reader = command.ExecuteReader();
			}
			Assert.True(reader.Read());
			Assert.Equal("test", reader.GetString(0));
			Assert.False(reader.Read());
		}
	}
