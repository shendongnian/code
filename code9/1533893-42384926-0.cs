    public class CustomEditorRenderer : EditorRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);
            var element = this.Element as CustomEditor;
            Control.InputAccessoryView = null;
            Control.ShouldEndEditing += DisableHidingKeyboard;
            MessagingCenter.Subscribe<ReportEventDetailPage>(this, "FocusKeyboardStatus", (sender) =>
            {
                if (Control != null)
                {
                    Control.ShouldEndEditing += EnableHidingKeyboard;
                }
                MessagingCenter.Unsubscribe<ReportEventDetailPage>(this, "FocusKeyboardStatus");
            });
        }
        private bool DisableHidingKeyboard(UITextView textView)
        {
            return false;
        }
        private bool EnableHidingKeyboard(UITextView textView)
        {
            return true;
        }
    }`
