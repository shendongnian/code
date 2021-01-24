    public class GetComponentGenericExample : MonoBehaviour
    {
        void Start()
        {
            GameObject gameObject = GameObject.Find("ObjectName")
            CustomCharacterSheet ccSheet = gameObject.GetComponent<CustomCharacterSheet>();
        }
    }
