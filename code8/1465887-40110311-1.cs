    public class EntryCellRenderer : EntryRenderer {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e) {
            ....
            UIEntry.OnFocusEventAction = () => //Your custom border color change code here
            ....
        }
    }
