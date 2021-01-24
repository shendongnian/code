    public class TestMono: MonoBehaviour
    {
        public static Dictionary<CustomClass, MonoBehaviour> classToMonoBehaviour;
    
        // Use this for initialization
        void Awake()
        {
            classToMonoBehaviour = new Dictionary<CustomClass, MonoBehaviour>();
    
            //Create and add class to the dictionary
            CustomClass cclas = new CustomClass();
            classToMonoBehaviour.Add(cclas, this);
        }
    }
