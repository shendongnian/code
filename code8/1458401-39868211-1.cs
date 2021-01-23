    public partial class LastPageView : UserControl
    {
        public LastPageView()
        {
            InitializeComponent();
            this.Loaded += (sender, args) =>
            {
                DialogParticipation.SetRegister(this, this.DataContext);
                ((IWizardPageLoadableViewModel) this.DataContext).LoadedCommand.Execute(this);
            };
            // if using DialogParticipation on Windows which open / close frequently you will get a
            // memory leak unless you unregister.  The easiest way to do this is in your Closing/ Unloaded
            // event, as so:
            //
            // DialogParticipation.SetRegister(this, null);
            this.Unloaded += (sender, args) => { DialogParticipation.SetRegister(this, null); };
        }
    }
