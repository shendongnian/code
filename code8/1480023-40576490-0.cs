        public class BaseFUHandler : MonoBehaviour, IFUHandler
        {
        public abstract void OnBlah(PointerEventData data);
        public void OnPointerDown(PointerEventData data)
        {
            //Gets called, but nothing hapends.
        }
