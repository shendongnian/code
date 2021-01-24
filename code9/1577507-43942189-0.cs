    public class ExtendedDatePicker : DatePicker
    {
        TextBox _textBox = null;
        
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            //subscribe to preview-lost-focus event
            _textBox = GetTemplateChild("PART_TextBox") as DatePickerTextBox;
            _textBox.AddHandler(TextBox.PreviewLostKeyboardFocusEvent, new RoutedEventHandler(TextBox_PreviewLostFocus), true);
        }
        private void TextBox_PreviewLostFocus(object sender, RoutedEventArgs e)
        {
            ValdateText(_textBox.Text);
        }
        private void ValdateText(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return;
            // ---- Add/update your valid date-formats here ----
            string[] formats = { "dd/MM/yyyy", "dd/M/yyyy", "d/M/yyyy", "d/MM/yyyy",
                    "MM/dd/yyyy", "M/dd/yyyy", "M/d/yyyy", "MM/d/yyyy"};
            CultureInfo culture = CultureInfo.InvariantCulture;
            DateTimeStyles styles = DateTimeStyles.None;
            DateTime temp;
            if (DateTime.TryParseExact(text, formats, culture, styles, out temp))
            { 
                //do nothing
            }
            else
            {
                //raise date-picker validation error event like ParseText does
                DatePickerDateValidationErrorEventArgs dateValidationError = 
                    new DatePickerDateValidationErrorEventArgs(new FormatException("String was not recognized as a valid DateTime."), text);
                OnDateValidationError(dateValidationError);
                _textBox.Text = string.Empty; //suppress parsing in base control by emptying text
            }
        }
    }
