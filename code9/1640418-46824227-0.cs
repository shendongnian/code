    public async Task ReadAllDataFromDevice(Func<Stream, Task> readCallback)
    {
    	using (var device = new Device())
        {
    		await device.Initialize();
    		using (var stream = new DeviceStream(device))
    		{
    			await readCallback(stream);
    		}
    	}
    }
