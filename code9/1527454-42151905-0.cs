    using UnityEngine;
	//	You'll need to include this namespace.
	using UniRx;
	//	This script will be responsible for translating a
	//	unity input-axis into an observable stream. 
	public class InputListener : MonoBehaviour {
		//	A Subject is an object that allows you to push events 
		//	into an observable stream by calling methods on it.
		private Subject<float> _inputSubject;
		//	We'll expose our Subject to other objects via this
		//	property since we don't want other objects to be able
		//	to push events into the stream.
		public IObservable<float> InputStream { get; private set; }
	
		public InputListener()
		{
			_inputSubject = new Subject<float>();
			//	Since we're observing real-time events, we'll make this a 
			//	"hot" observable.
			var connected = _inputSubject.AsObservable().Publish();
			connected.Connect();
			InputStream = connected;
		}
		[SerializeField]
		private string _inputAxis;
		public string InputAxis
		{
			get { return _inputAxis; }
			set { _inputAxis = value; }
		}
	
		// Update is called once per frame
		void Update () {
			//	This will push the current value of the axis that's
			//	being observed into the stream. Clients will be able
			//	to perform on the stream, similar to how you can perform
			//	operations on IEnumerable by using LINQ methods.
			_inputSubject.OnNext(Input.GetAxis(_inputAxis));
		}
	}
