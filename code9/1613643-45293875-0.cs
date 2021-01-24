    public class GetComponentGenericExample : MonoBehaviour
    {
        void Start()
        {
            GameObject object = GameObject.Find("ObjectName")
            CustomCharacterSheet ccSheet = object.GetComponent<CustomCharacterSheet>();
        }
    }
