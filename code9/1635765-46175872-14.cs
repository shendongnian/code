	public class Modem : IHardwareDevice
	{
		IDeviceStateFactory _stateFactory;
		IDeviceState _currentState;
		public Modem(IDeviceStateFactory stateFactory)
		{
			_stateFactory = stateFactory;
			SwitchOn();
		}
		void SwitchOn()
		{
			_currentState = _stateFactory.GetOnline();
		}
	}
