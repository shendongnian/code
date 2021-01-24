	public Task<DeviceResult> DeviceFetchAsync(int device_number, Action<TimeSpan> reschedule)
	{
		if (device_number == 1)
		{
			reschedule(TimeSpan.FromMilliseconds(10000));
		}
	
		return Task.Factory.StartNew(() => new DeviceResult()
		{
			DeviceNumber = device_number
		});
	}
	
	public class DeviceResult
	{
		public int DeviceNumber;
	}
