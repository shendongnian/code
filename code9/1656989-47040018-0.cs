    public interface IDropdownContext
    {
        void OnDropdownSelected(BaseEventData eventData);
    }
    public class Test : MonoBehaviour, IDropdownContext
    {
        public void OnDropdownSelected(BaseEventData eventData)
        {
            Debug.Log("OnDropdownSelected");
        }
    }
    public class LanguageDropdown : MonoBehaviour, ISelectHandler// required interface when using the OnSelect method.
    {
        [SerializeField]
        public Test context;
        //Do this when the selectable UI object is selected.
        public void OnSelect(BaseEventData eventData)
        {
            Debug.Log(this.gameObject.name + " was selected");
            context.OnDropdownSelected(eventData);
        }
    }
