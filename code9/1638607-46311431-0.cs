	public static partial class CommManager
	{
		public static class ValueListenManager
		{
			public static event Action<object> NewValueAvailable;
			
			private static Thread s_valueQueryThread;
			private static ActionBlock<object> s_newValueActionBlock;
			private static bool s_shouldRun;
			
			private static Random s_valueGenerator; //for testing purposes
			
			public static void Start()
			{
				//These flow options will make sure your action block executes on the UI thread. Make sure you call start on the UI Thread!
				var flowOptions = new ExecutionDataflowBlockOptions(){ TaskScheduler = TaskScheduler.FromCurrentSynchronizationContext() };
				
				s_newValueActionBlock = new ActionBlock<object>(new Action<object>(OnNewValue), flowOptions);
				s_valueQueryThread = new Thread(CheckPlcValues);
				
				s_valueQueryThread.IsBackground = true;
				s_valueQueryThread.Start();
			}
			
			public static void Stop()
			{
				s_shouldRun = false;
				
				s_valueQueryThread.Join();
				s_valueQueryThread = null;
				
				s_newValueActionBlock.Complete();
				s_newValueActionBlock = null;
			}
			
			private static void OnNewValue(object value)
			{
				if(NewValueAvailable != null)
					NewValueAvailable(value);
			}
			
			private static void CheckPlcValues()
			{
				s_shouldRun = true;
				
				while(s_shouldRun)
				{
					var curPlcValue = s_valueGenerator.Next(1, 5);
					
					s_newValueActionBlock.Post(curPlcValue);
					
					Thread.Sleep(1000);
				}
			}
		}
	}
	
	internal class ValueListener
	{
		public event EventHandler<ValueChangeEventArgs> ValueChanged;
		
		public string FullPath { get; private set; }
		public object Value { get; private set; }
		
		internal ValueListener(string path)
		{
			this.FullPath = path;
			CommManager.ValueListenManager.NewValueAvailable += CommManager_ValueListenManager_NewValueAvailable;
		}
		
		~ValueListener()
		{
			CommManager.ValueListenManager.NewValueAvailable -= CommManager_ValueListenManager_NewValueAvailable;
		}
		void CommManager_ValueListenManager_NewValueAvailable(object newValue)
		{
			if(newValue == null)
				return;
			
			if(!newValue.Equals(Value))
			{
				var args = new ValueChangeEventArgs(newValue, Value);
				Value = newValue;
				
				if(ValueChanged != null)
					ValueChanged(this, args);
			}
		}
	}
	
	public class ValueChangeEventArgs : EventArgs
	{
		public ValueChangeEventArgs(object Value, object OldValue) { }
	}
