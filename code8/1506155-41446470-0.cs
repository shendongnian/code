	Timer[] timers = new Timer[Wavcount];
	for (int i=0; i < Wavcount; i++)
    {
		Timer t1 = new Timer();
		t1.Interval = 1000;
		t1.Elapsed += (s, e) => SomeStaticMethod(s as Timer, e.SignalTime, "Timer " + i);
		t1.Start();
	}
	private static void SomeStaticMethod(Timer timer, DateTime signalTime, string timerName)
    {
        Console.WriteLine(timerName + " fired at " + signalTime);
	}
