    public static class FormExtensions
    {
        // Slightly shorter name
        public static void ShowAndFront(this Form form)
        {
            form.Show();
            form.BringToFront();
        }
    }
