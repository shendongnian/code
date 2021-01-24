    private bool _lieAboutCurrentFocus;
        public override bool DispatchTouchEvent(MotionEvent ev)
        {
            var focused = CurrentFocus;
            bool customEntryRendererFocused = focused != null && focused.Parent is YourCustomEditorRenderer;
            _lieAboutCurrentFocus = customEntryRendererFocused;
            var result = base.DispatchTouchEvent(ev);
            _lieAboutCurrentFocus = false;
            return result;
        }
        public override Android.Views.View CurrentFocus
        {
            get
            {
                if (_lieAboutCurrentFocus)
                {
                    return null;
                }
                return base.CurrentFocus;
            }
        }
