    using UnityEngine;
	using System;
	using UniRx;
	using System.Linq;
	[RequireComponent(typeof(InputListener))]
	public class RespondToSwipe : MonoBehaviour {
		[SerializeField]
		private float _groupSizeInSeconds = 1;
		private InputListener _inputSource;
	
		void Start () {
			_inputSource = GetComponent<InputListener>();
			//	Observable streams can be operated on in a similar fashion
			//	to IEnumerable sequences.
			var stream = _inputSource.InputStream
				//	This method groups events by time. For example, if _groupSizeInSeconds is
				//	set to 1, then the output stream will fire an event every second,
				//	and the element of that stream will be a list of all events that happened
				//	during the last second.
				.Buffer(TimeSpan.FromSeconds(_groupSizeInSeconds))
				//	Because we only want a single swipe event, we simply take the first event
				//	from the buffer. 
				.Select(x => x.First());
			stream.Subscribe(
				x => Debug.Log("GotInput: " + x), 
				x => Debug.Log("Error: " + x.Message));
		}
	}
