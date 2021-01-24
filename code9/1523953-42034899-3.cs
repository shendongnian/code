    public class TestScript: MonoBehaviour
    {
        private Action someListener;
    
        void Awake()
        {
            someListener = new Action(SomeFunction);
            StartCoroutine(invokeTest());
        }
    
        IEnumerator invokeTest()
        {
            WaitForSeconds waitTime = new WaitForSeconds(2);
            while (true)
            {
                yield return waitTime;
                EventManager.TriggerEvent("test");
                yield return waitTime;
                EventManager.TriggerEvent("Spawn");
                yield return waitTime;
                EventManager.TriggerEvent("Destroy");
            }
        }
    
        void OnEnable()
        {
            EventManager.StartListening("test", someListener);
            EventManager.StartListening("Spawn", SomeOtherFunction);
            EventManager.StartListening("Destroy", SomeThirdFunction);
        }
    
        void OnDisable()
        {
            EventManager.StopListening("test", someListener);
            EventManager.StopListening("Spawn", SomeOtherFunction);
            EventManager.StopListening("Destroy", SomeThirdFunction);
        }
    
        void SomeFunction()
        {
            Debug.Log("Some Function was called!");
        }
    
        void SomeOtherFunction()
        {
            Debug.Log("Some Other Function was called!");
        }
    
        void SomeThirdFunction()
        {
            Debug.Log("Some Third Function was called!");
        }
    }
