    public class SelectHandler : MonoBehaviour
    {
        public delegate void SelectedHandlerDelegate(string nameTag);
        public static SelectedHandlerDelegate SelectedHandler;
        ....
            //call 
            UnityEngine.WSA.Application.InvokeOnUIThread(() => SelectedHandler("teststring"), false);
