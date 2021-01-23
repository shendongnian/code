    public abstract class Trap : MonoBehaviour {
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
                Trigger(other.transform);
        } 
        protected abstract void Trigger (Transform victim);
    }
