    public class MonoScript : MonoBehaviour
    {
        void Start()
        {
            NonMonoScript  nonMonoScript = new NonMonoScript();
            //Pass MonoBehaviour to non MonoBehaviour class
            nonMonoScript.monoParser(this);
        }
    }
