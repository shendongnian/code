    public class DatePicker2 : DatePicker 
    {
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            if (GetTemplateChild("PART_TextBox") is TextBox textBox)
            {
                textBox.IsReadOnly = true;
            }
        }
    }
