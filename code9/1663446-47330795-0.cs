	private byte[] ReadRabbitMsg(IModel channel, string queue)
	{
		if (channel.MessageCount(queue) == 0) return null;
		BasicGetResult result = channel.BasicGet(queue, true);
		if (result == null) return null;
		else
		{
			IBasicProperties props = result.BasicProperties;
			byte[] buff = result.Body;
		}
	}
