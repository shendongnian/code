    public partial class YourForm : Form
    {
        private LocalizationViewModel _viewmodel;
        public YourForm()
        {
            InitializeComponent();
            _viewmodel = new LocalizationViewModel();
            // Bound controls to correspondent viewmodel's properties
            LblTitle.DataBindings.Add("Text", _viewmodel, "Title", true);
            LblDescription.DataBindings.Add("Text", _viewmodel, "Description", true);
        }
        // Menu buttons to change language
        private void SpanishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _viewmodel.SetLanguage("es");
        }
        private void EnglishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _viewmodel.SetLanguage("en");
        }
    }
