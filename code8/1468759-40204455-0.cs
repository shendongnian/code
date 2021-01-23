    public static class ExtensionMethods
    {
        public static void ResetTransformation(this Transform trans)
        {
        }
    }
**...**
    public class SomeClass : MonoBehaviour 
    {
        void Start () {
            transform.ResetTransformation();
        }
    }
