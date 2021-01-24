    public static class FormHelper
    {
        public static void ShowInvisible(this Form form)
        {
            // saving original settings
            bool needToShowInTaskbar = form.ShowInTaskbar;
            FormWindowState initialWindowState = form.WindowState;
            // making form invisible
            form.ShowInTaskbar = false;
            form.WindowState = FormWindowState.Minimized;
            // showing and hiding form
            form.Show();
            form.Hide();
            // restoring original settings
            form.ShowInTaskbar = needToShowInTaskbar;
            form.WindowState = initialWindowState;
        }
    } 
