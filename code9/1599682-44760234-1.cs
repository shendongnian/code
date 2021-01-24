    public static class FormExtensions
    {
        // Slightly shorter name
        public static Form ShowAndFront(this Form form)
        {
            form.Show();
            form.BringToFront();
            return form;
        }
    }
