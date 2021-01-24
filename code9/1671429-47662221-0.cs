    public static class FormExtensions
    {
        public static Form SetFormProperties(this Form form)
        {
            form.Height = 100;
            form.Width = 100;
            form.StartPosition = FormStartPosition.WindowsDefaultLocation;
            form.ShowInTaskbar = true;
            return form;
        }
    }
