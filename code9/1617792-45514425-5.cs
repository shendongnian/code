    public class GenericForm<TObject> : Form where TObject : class
    {
        // Here you can do whatever you want,
        // exactly like the example code in the
        // first lines of your question
        public TObject GenericType { get; set; }
        public GenericForm()
        {
            // To show that this actually works,
            // I'll handle the Paint event, because
            // it is executed AFTER the window is shown.
            Paint += GenericForm_Paint;
        }
        private void GenericForm_Paint(object sender, EventArgs e)
        {
            // Let's print the type of TObject to see if it worked:
            MessageBox.Show(typeof(TObject).ToString());
        }
    }
