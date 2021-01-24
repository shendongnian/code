    public class LanguageDropdown : MonoBehaviour, ISelectHandler// required interface when using the OnSelect method.
    {
        public UnityEvent Selected;
        //Do this when the selectable UI object is selected.
        public void OnSelect(BaseEventData eventData)
        {
            Debug.Log(this.gameObject.name + " was selected");
            Selected.Invoke();
        }
    }
