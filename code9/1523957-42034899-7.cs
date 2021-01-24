    public class Test : MonoBehaviour
    {
        private Action<EventParam> someListener1;
        private Action<EventParam> someListener2;
        private Action<EventParam> someListener3;
    
        void Awake()
        {
            someListener1 = new Action<EventParam>(SomeFunction);
            someListener2 = new Action<EventParam>(SomeOtherFunction);
            someListener3 = new Action<EventParam>(SomeThirdFunction);
    
            StartCoroutine(invokeTest());
        }
    
        IEnumerator invokeTest()
        {
            WaitForSeconds waitTime = new WaitForSeconds(0.5f);
    
            //Create parameter to pass to the event
            EventParam eventParam = new EventParam();
            eventParam.param1 = "Hello";
            eventParam.param2 = 99;
            eventParam.param3 = 43.4f;
            eventParam.param4 = true;
    
            while (true)
            {
                yield return waitTime;
                EventManager.TriggerEvent("test", eventParam);
                yield return waitTime;
                EventManager.TriggerEvent("Spawn", eventParam);
                yield return waitTime;
                EventManager.TriggerEvent("Destroy", eventParam);
            }
        }
    
        void OnEnable()
        {
            //Register With Action variable
            EventManager.StartListening("test", someListener1);
            EventManager.StartListening("Spawn", someListener2);
            EventManager.StartListening("Destroy", someListener3);
    
            //OR Register Directly to function
            EventManager.StartListening("test", SomeFunction);
            EventManager.StartListening("Spawn", SomeOtherFunction);
            EventManager.StartListening("Destroy", SomeThirdFunction);
        }
    
        void OnDisable()
        {
            //Un-Register With Action variable
            EventManager.StopListening("test", someListener1);
            EventManager.StopListening("Spawn", someListener2);
            EventManager.StopListening("Destroy", someListener3);
    
            //OR Un-Register Directly to function
            EventManager.StopListening("test", SomeFunction);
            EventManager.StopListening("Spawn", SomeOtherFunction);
            EventManager.StopListening("Destroy", SomeThirdFunction);
        }
    
        void SomeFunction(EventParam eventParam)
        {
            Debug.Log("Some Function was called!");
        }
    
        void SomeOtherFunction(EventParam eventParam)
        {
            Debug.Log("Some Other Function was called!");
        }
    
        void SomeThirdFunction(EventParam eventParam)
        {
            Debug.Log("Some Third Function was called!");
        }
    }
