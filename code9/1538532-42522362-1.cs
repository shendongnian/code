    async Task Send()
    {
    	using(SmtpClient c = new SmtpClient())
    	using(var cts = new CancellationTokenSource(30000))
    	{
    		cts.Token.Register(c.SendAsyncCancel);
    		await c.SendMailAsync("a@a.a","b@b.b","foo","bar");
    	}
    }
