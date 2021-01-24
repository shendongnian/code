	// Use this for initialization
	private void Start(){
		var keyCode = new[]{"W", "A", "S", "D"};
		var updateTick = this.UpdateAsObservable();
		// Get a stream for each key
		var w = updateTick.Where(_ => Input.GetKeyDown(KeyCode.W)).Select(_ => "W");
		var s = updateTick.Where(_ => Input.GetKeyDown(KeyCode.S)).Select(_ => "S");
		var d = updateTick.Where(_ => Input.GetKeyDown(KeyCode.D)).Select(_ => "D");
		var a = updateTick.Where(_ => Input.GetKeyDown(KeyCode.A)).Select(_ => "A");
		// Display the pressed key
		w.Subscribe(Debug.Log).AddTo(this);
		s.Subscribe(Debug.Log).AddTo(this);
		d.Subscribe(Debug.Log).AddTo(this);
		a.Subscribe(Debug.Log).AddTo(this);
		// Stream of all previous keys combined
		var keyStream = Observable.Merge(w, a, s, d);
		// Stream of events when sequence is found
		var keyCodeFound = keyStream.Where(key => key == keyCode.First())
			.SelectMany(key => keyStream.StartWith(key).Buffer(keyCode.Length).First())
			.Where(list => list.SequenceEqual(keyCode));
		// Whenever the sequence is found, a message is displayed on the screen
		keyCodeFound.Subscribe(CombiHappened(), Debug.LogException)
			.AddTo(this);
	}
	private static System.Action<IList<string>> CombiHappened() => items => {
		Debug.LogWarning("Key combination happened! " + string.Join(",", items.ToArray()));
	};
