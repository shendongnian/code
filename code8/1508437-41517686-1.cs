    public class StickyTextBox : TextBox
    {
        private string _lastText = string.Empty;
        private long _ticksAtLastKeyDown;
        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            _ticksAtLastKeyDown = DateTime.Now.Ticks;
            base.OnPreviewKeyDown(e);
        }
        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            if (!IsInitialized)
                _lastText = Text;
            if (IsFocused)
            {
                var elapsed = new TimeSpan(DateTime.Now.Ticks - _ticksAtLastKeyDown);
                // If the time between the last keydown event and our text change is
                // very short, we can be fairly certain than text change was caused
                // by the user.  We update the _lastText to store their new user input
                if (elapsed.TotalMilliseconds <= 5) {
                    _lastText = Text;
                }
                else {
                    // if our last keydown event was more than a few seconds ago,
                    // it was probably an external change
                    Text = _lastText;
                    e.Handled = true;
                }
            }
            base.OnTextChanged(e);
        }
    }
