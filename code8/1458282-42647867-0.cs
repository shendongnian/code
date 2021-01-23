	const float DELAY = .5f;
	void Start()
	{
		recognizer = new GestureRecognizer();
		recognizer.StartCapturingGestures();
		recognizer.SetRecognizableGestures(GestureSettings.Tap | GestureSettings.DoubleTap);
		recognizer.TappedEvent += (source, tapCount, ray) =>
		{
			if (tapCount == 1)
				Invoke("SingleTap", DELAY);
			else if (tapCount == 2)
			{
				CancelInvoke("SingleTap");
				DoubleTap();
			}
		};
	}
	void SingleTap()
	{
		Debug.Log("Single Tap")
	}
	void DoubleTap()
	{
		Debug.Log("Double Tap")
	}
