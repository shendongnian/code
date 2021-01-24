    public class ObjectItemViewModel : MvxViewModel<ObjectItem>
    {
        public ObjectItemViewModel() { }
        public void Init(ObjectItem obj)
        {
            Obj = obj;
            loadItems();
        }
        // rest of code
    }
