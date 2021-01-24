    public class MainActivity : Activity
	{
		DateTime startTime = DateTime.Now;
		Thread thread;
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences (this);
			ISharedPreferencesEditor editor = prefs.Edit ();
			long memStartTime = prefs.GetLong ("startTime", 0);
			if (memStartTime != 0) {
				startTime = new DateTime (memStartTime);
			} else {
				editor.PutLong ("startTime", startTime.Ticks);
				editor.Apply();
			}
			TimerUpdate ();
		}
		void TimerUpdate () {
			if (thread == null) {
				thread = new Thread (delegate () {
					while (true) {
						Thread.Sleep (1000);
						DateTime curTime = DateTime.Now;
						Console.WriteLine (curTime - startTime);
						//Update your on screen textview.
					}
				});
				thread.Start ();
			}
		}
	}
