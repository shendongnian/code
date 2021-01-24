    public class ObjectViewModel : ObjectItemViewModel
    {
        public override void ShowItem()
        {
            ShowViewModel<ObjectViewModel, ObjectItem>(Obj);
        }
    }
