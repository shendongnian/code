	enum ReadOrWrite { Read, Write }
	void Foo()
	{
		try
		{
			socket.Receive();
		}
		catch (IOException ex)
		{
			ex.Data.Add("readOrWrite", ReadOrWrite.Read);
			throw;
		}
	}
