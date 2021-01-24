    public class GenericForm<TObject> : Form where TObject : class
    {
        public TObject GenericType { get; set; }
        public GenericForm()
        {
            Paint += GenericForm_Paint;
        }
        private void GenericForm_Paint(object sender, EventArgs e)
        {
            MessageBox.Show(typeof(TObject).ToString());
        }
    }
