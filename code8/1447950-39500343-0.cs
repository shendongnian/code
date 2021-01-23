    public class FormManager
    {
        public T ShowForm<T>()
            where T : Form, new()
        {
            var t = new T();
            t.OnFormClosing += DisposeForm;
            return t;
        }
        void DisposeForm(object sender, FormClosedEventArgs args)
        {
            ((Form)sender).Dispose();
        }
    }
