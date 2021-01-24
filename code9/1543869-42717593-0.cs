    public class DefaultTrackableEventHandler : MonoBehaviour,
                                                ITrackableEventHandler
    {
        private TrackableBehaviour mTrackableBehaviour;
        [SerializedField] private MyConditionClass actionMb = null;
        protected virtual void Start()
        {
            mTrackableBehaviour = GetComponent<TrackableBehaviour>();
            if (mTrackableBehaviour)
            {
                mTrackableBehaviour.RegisterTrackableEventHandler(this);
            }
        }
        public void OnTrackableStateChanged(
                                        TrackableBehaviour.Status previousStatus,
                                        TrackableBehaviour.Status newStatus)
        {
            if (newStatus == TrackableBehaviour.Status.DETECTED ||
                newStatus == TrackableBehaviour.Status.TRACKED ||
                newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
            {
  
                OnTrackingFound();
            }
            else
            {
                OnTrackingLost();
            }
        }
        protected virtual void OnTrackingFound()
        {
            // Was already successfully done
            if(this.actionMb.ConditionMet == true){ return; }
            this.actionMb.enable = true;
        }
        protected virtual void OnTrackingLost()
        {
            // Was already successfully done
            if(this.actionMb.ConditionMet == true){ return; }
            this.actionMb.enable = false;
        }
    }
    
    public abstract class MyConditionClass : MonoBehaviour
    {   
        public bool ConditionMet{ get; private set; }
        protected abstract bool CheckCondition();
        protected virtual void Update(){
            if(ConditionMet == true){ return; }
            ConditionMet = CheckCondition();
        }
    }  
    public class MyConditionClassForInput : MyConditionClass 
    {   
        protected override bool CheckCondition(){
            return (Input.GetKeyDown(KeyCode.Space));
        }
    }
