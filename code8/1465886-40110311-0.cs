    public class CustomEntryCell : EntryCell {
        public Action OnFocusEventAction { get; set; }
        public CustomEntryCell() { Focused += OnFocused }
        private void OnFocused(object sender, FocusEventArgs focusEventArgs) { OnFocusEventAction?.Invoke(); }
        ///Or if you are not at C# 6 yet:
        //private void OnFocused(object sender, FocusEventArgs focusEventArgs) {
        //    Action action = OnFocusEventAction;
        //    if(action != null) { action.Invoke(); }
        //}
    }
