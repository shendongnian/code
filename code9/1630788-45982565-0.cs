    public class testscript : MonoBehaviour
    {
        public int foo; // shows up in inspector
        [SerializeField] private int bar; // also shows up while still being private
    
    	void Start()
        {
    	}
    }
