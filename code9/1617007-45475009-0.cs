    public class TextBoxMaxLengthBehavior : Behavior<TextBox>
    {
        public static readonly DependencyProperty MaxLengthProperty =
            DependencyProperty.Register(
                nameof(MaxLength),
                typeof(int),
                typeof(TextBoxMaxLengthBehavior),
                new FrameworkPropertyMetadata(0));
        public int MaxLength
        {
            get { return (int) GetValue(MaxLengthProperty); }
            set { SetValue(MaxLengthProperty, value); }
        }
        public static readonly DependencyProperty LengthEncodingProperty =
            DependencyProperty.Register(
                nameof(LengthEncoding),
                typeof(Encoding),
                typeof(TextBoxMaxLengthBehavior),
                new FrameworkPropertyMetadata(Encoding.Default));
        public Encoding LengthEncoding
        {
            get { return (Encoding) GetValue(LengthEncodingProperty); }
            set { SetValue(LengthEncodingProperty, value); }
        }
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.PreviewTextInput += PreviewTextInputHandler;
            DataObject.AddPastingHandler(AssociatedObject, PastingHandler);
        }
        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.PreviewTextInput -= PreviewTextInputHandler;
            DataObject.RemovePastingHandler(AssociatedObject, PastingHandler);
        }
        private void PreviewTextInputHandler(object sender, TextCompositionEventArgs e)
        {
            string text;
            if (AssociatedObject.Text.Length < AssociatedObject.CaretIndex)
                text = AssociatedObject.Text;
            else
            {
                //  Remaining text after removing selected text.
                string remainingTextAfterRemoveSelection;
                text = TreatSelectedText(out remainingTextAfterRemoveSelection)
                    ? remainingTextAfterRemoveSelection.Insert(AssociatedObject.SelectionStart, e.Text)
                    : AssociatedObject.Text.Insert(AssociatedObject.CaretIndex, e.Text);
            }
            e.Handled = !ValidateText(text);
        }
        private bool TreatSelectedText(out string text)
        {
            text = null;
            if (AssociatedObject.SelectionLength <= 0)
                return false;
            var length = AssociatedObject.Text.Length;
            if (AssociatedObject.SelectionStart >= length)
                return true;
            if (AssociatedObject.SelectionStart + AssociatedObject.SelectionLength >= length)
                AssociatedObject.SelectionLength = length - AssociatedObject.SelectionStart;
            text = AssociatedObject.Text.Remove(AssociatedObject.SelectionStart, AssociatedObject.SelectionLength);
            return true;
        }
        private void PastingHandler(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(DataFormats.Text))
            {
                var pastedText = Convert.ToString(e.DataObject.GetData(DataFormats.Text));
                var text = ModifyTextToFit(pastedText);
                if (!ValidateText(text))
                    e.CancelCommand();
                else if (text != pastedText)
                    e.DataObject.SetData(DataFormats.Text, text);
            }
            else
                e.CancelCommand();
        }
        private string ModifyTextToFit(string text)
        {
            var result = text.Remove(MaxLength);
            while (!string.IsNullOrEmpty(result) && !ValidateText(result))
                result = result.Remove(result.Length - 1);
            return result;
        }
        private bool ValidateText(string text)
        {
            return LengthEncoding.GetByteCount(text) <= MaxLength;
        }
    }
