    public class MyEventReceiver : AAREventReceiver {
        public abstract void OnMarkerFound(ARTrackable marker){
            //log OnMarkerFound
        }
        public abstract void OnMarkerTracked(ARTrackable marker){
            //log OnMarkerTracked
        }
        public abstract void OnMarkerLost(ARTrackable marker){
            //log OnMarkerLost
        }
    }
