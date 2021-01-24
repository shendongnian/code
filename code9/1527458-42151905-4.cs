	using UnityEngine;
	//	You'll need to include these namespaces.
	using UniRx;
	using System.Linq;
	using System;
	//	This will be responsible for converting unity input
	//	into a stream of events.
	public class SwipeListener : MonoBehaviour
	{
		//	Rx Subjects allow you to create an observable stream of your
		//	own. You can push events to the stream by calling OnNext(). 
		private Subject<float> _subject;
		//	We'll expose the above stream via this property for a couple reasons.
		//	1) If we exposed the subject directly, other code could push events to
		//		our stream by calling OnNext(). Preventing that helps avoid bugs.
		//	2) We'll be filtering the stream to avoid having too many swipe-events.
		public IObservable<float> InputStream { get; private set; }
		//	Event values will be grouped by threes and averaged
		//	to smooth out noise.
		[SerializeField]
		private int _bufferCount = 3;
		//	Average displacement level below which no swipe event
		//	will be triggered.
		[SerializeField]
		private float _minimumThreshhold = 15;
		//	To prevent back-to-back swipe events. 
		[SerializeField]
		private float _slidingTimeoutWindowSeconds = .25f;
		private void Update()
		{
			//	We push values to our stream by calling OnNext() on our
			//	Subject in each game step. 
			_subject.OnNext(GetInputValue());
		}
		//	Here is where we get the value that will be pushed into the stream.
		//	For this demonstration, I'm using the mouse-position. You could easily
		//	override this and return touch positions instead.
		protected virtual float GetInputValue()
		{
			return Input.mousePosition.x;
		}
		public SwipeListener()
		{
			_subject = new Subject<float>();
			//	This is where the real magic happens. IObservable supports many of the
			//	same LINQ operations as IEnumerable.
			IObservable<float> filtered = _subject
				//	Convert stream of horizontal mouse positions into a stream of 
				//	mouse speed values.
				.Pairwise()
				.Select(x => x.Current - x.Previous)
				//	Group events and average them to smooth out noise. The group size
				//	can be configured in the inspector.
				.Buffer(_bufferCount)
				.Select(x => x.Average())
				//	Filter out events if the mouse was not moving quickly enough. This
				//	can be configured in the inspector. You'll want to play around with this.
				.Where(x => Mathf.Abs(x) > _minimumThreshhold);
			//	Now we'll apply a sliding timeout window to throttle our stream. this
			//	will help prevent multiple back-to-back swipe events when you swipe once.
			//	I've split the event stream into two separate streams so we can throttle
			//	left and right swipes separately. This will help ensure that there isn't 
			//	unnecessary lag when swiping left after having swiped right, or vice-versa.
			TimeSpan seconds = TimeSpan.FromSeconds(_slidingTimeoutWindowSeconds);
			IObservable<float> left = filtered
				.Where(x => x < 0)
				.Throttle(seconds);
			IObservable<float> right = filtered
				.Where(x => x > 0)
				.Throttle(seconds);
			//	Now that we've throttled left and right swipes separately, we can merge 
			//	them back into a single stream. 
			InputStream = left.Merge(right);
		}
	}
