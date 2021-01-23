    public class example : MonoBehaviour {
    
    void Start()
    {
        RunZebra();
    }
    void RunZebra() {
            Zebra other = GetComponent<Zebra>();
            other.RunIt();
        }
     }
