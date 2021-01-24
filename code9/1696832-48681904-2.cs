	private async void buttonStart_Click(object sender, EventArgs e)
	{
        // If the ping loops are already running, don't start them again
		if (run)
			return;
		run = true;
        // Get all IPs (in my case from a TextBox instead of a ListBox
		string[] ips = txtIPs.Text.Split(new[] {"\r\n"}, StringSplitOptions.RemoveEmptyEntries);
        // Create an array to store all Tasks
		Task[] pingTasks = new Task[ips.Length];
        // Loop through all IPs
		for(int i = 0; i < ips.Length; i++)
		{
			string ip = ips[i];
            
            // Launch and store a task for each IP
			pingTasks[i] = Task.Run(async () =>
				{
                    // while run is true, ping over and over again
					while (run)
					{
                        // Ping IP and wait for result (instead of storing it an a global array)
						var result = await PingStart(ip);
                        // Print the result (here I removed seqnum)
						PrintResult(result.Item2);
                        
                        // This line is optional. 
                        // If you want to blast pings without delay, 
                        // you can remove it
						await Task.Delay(1000);
					}
				}
			);
		}
        // Wait for all loops to end after setting run = false.
        // You could add a mechanism to call isPing.SendAsyncCancel() instead of waiting after setting run = false
		foreach (Task pingTask in pingTasks)
			await pingTask;
	}
	
    // (very) simplified explanation of changes:
    // async = this method is async (and therefore awaitable)
    // Task<> = This async method returns a result of type ...
    // Tuple<bool, string> = A generic combination of a bool and a string
    // (-)int seqnum = wasn't used so I removed it
	private async Task<Tuple<bool, string>> PingStart(string ip)
	{
		Ping isPing = new Ping();
		const int timeout = 2000;
		const string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
		var buffer = Encoding.ASCII.GetBytes(data);
		PingOptions options = new PingOptions {DontFragment = false};
        // await SendPingAsync = Ping and wait without blocking
		PingReply reply = await isPing.SendPingAsync(ip, timeout, buffer, options);
		string rtt = reply.RoundtripTime.ToString();
		bool success = reply.Status == IPStatus.Success;
		string text;
		if (success)
		{
			text = $"{ip}" + " Success!" + $" rtt: [{rtt}]" + $"Thread: {Thread.CurrentThread.GetHashCode()} Is pool thread: {Thread.CurrentThread.IsThreadPoolThread}";
		}
		else
		{
			text = $"{ip}" + $" Not Successful! Status: {reply.Status}" + $"Thread: {Thread.CurrentThread.GetHashCode()} Is pool thread: {Thread.CurrentThread.IsThreadPoolThread}";
		}
        // return if the ping was successful and the status message
		return new Tuple<bool, string>(success, text);
	}
