    public class YourScript: MonoBehaviour
    {
        void Start()
        {
            GameObject[] obj = GameObject.FindGameObjectsWithTag("car");
            Debug.Log("Length: " + obj.Length);
    
            for (int i = 0; i < obj.Length; i++)
            {
                Debug.Log(obj[i].name, obj[i]);
            }
        }
    }
