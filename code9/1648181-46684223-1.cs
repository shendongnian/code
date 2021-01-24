    public class Itemslot : MonoBehaviour, IDropHandler, IPointerEnterHandler, 
    IPointerExitHandler, ISerializationCallbackReceiver
    {
        public HashSet<GlobalEnums.ItemType> typeAllowed = new HashSet<GlobalEnums.ItemType>();
        // private field to ensure serialization
        [SerializeField]
        private List<GlobalEnums.ItemType> _typeAllowedList = new List<GlobalEnums.ItemType>();
        public void OnBeforeSerialize()
        {
            // store HashSet contents in List
            _typeAllowedList.Clear();
            foreach(var allowedType in typeAllowed)
            {
                _typeAllowedList.Add(allowedType);
            }
        }
        public void OnAfterDeserialize()
        {
            // load contents from the List into the HashSet
            typeAllowed.Clear();
            foreach(var allowedType in _typeAllowedList)
            {
                typeAllowed.Add(allowedType);
            }
        }
    }
