    public class Trigger : MonoBehaviour 
    {
        public UnityEvent OnEnter;
    
        [SerializeField]
        private string tag;
        
        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag(tag) && OnEnter != null)
                OnEnter.Invoke();
        }
    }
