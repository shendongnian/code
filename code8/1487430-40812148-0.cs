    class Network : MonoBehaviour
    {
        private Data d;
        Text label;
    
        private System.Object threadLocker = new System.Object();
    
        public void Start()
        {
            label = GameObject.Find("textObject").GetComponent<Text>();
    
            // setting up handler to async fetch data and call provided callback
            Networking.GetData(s => ParsePayload(s));
        }
    
        private void ParsePayload(string payload)
        {
            lock (threadLocker)
            {
                d = JsonConvert.DeserializeObject<Data>(payload);
            }
        }
    
        public void Update()
        {
            lock (threadLocker)
            {
                label.text = d.Name;
            }
        }
    }
