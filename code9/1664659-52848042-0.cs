    public class UIContainer : MonoBehaviour {
        private static UIContainer instance = null;
        public static UIContainer Instance {
            get {
                return instance;
            }
        }
        [SerializeField] GameObject[] uiInstances;
        void Awake() {
            instance = this;
        }
        void OnDestroy() {
            instance = null;
        }
        public GameObject GetUI(string uiName)
        {
            GameObject ui = null;
            foreach(GameObject inst in uiInstances){
                if(inst.name == uiName){
                    ui = inst;
                    break;
                }
            }
            return ui;
        }
    }
