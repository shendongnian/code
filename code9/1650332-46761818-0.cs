    public class CustomTrackableEventHandler : MonoBehaviour,
                                               ITrackableEventHandler
    {
        ...
    
        public void OnTrackableStateChanged(
                                        TrackableBehaviour.Status previousStatus,
                                        TrackableBehaviour.Status newStatus)
        {
            if (newStatus == TrackableBehaviour.Status.DETECTED ||
                newStatus == TrackableBehaviour.Status.TRACKED ||
                newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
            {
                OnTrackingFound(); 
                // **** Your own logic here ****
            }
            else
            {
                OnTrackingLost();
            }
        }
    }
		
