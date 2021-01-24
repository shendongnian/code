    public class GetComponentGenericExample : MonoBehaviour
    {
        void Start()
        {
            GameObject gObject = GameObject.Find("ObjectName")
            CustomCharacterSheet ccSheet = gObject.GetComponent<CustomCharacterSheet>();
        }
    }
