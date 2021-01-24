    public class LanguageDropdown : MonoBehaviour, ISelectHandler// required interface when using the OnSelect method.
    {
        public delegate void SelectAction(GameObject target);
        public static event SelectAction OnSelectedEvent;
    
        //Do this when the selectable UI object is selected.
        public void OnSelect(BaseEventData eventData)
        {
            Debug.Log(this.gameObject.name + " was selected");
    
            //Invoke Event
            if (OnSelectedEvent != null)
            {
                OnSelectedEvent(this.gameObject);
            }
        }
    }
