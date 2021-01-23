    public class YourForm: Form
    {
        public YourForm()
        {
            InitializeComponent();
            var dealers = new List<DealerViewModelBase>
            {
                new Dealer1ViewModel (),
                new Dealer2ViewModel ()
            };
            var bindSource = new BindingList<DealerViewModelBase>(dealers);
            DgvDealers.DataSource = bindSource;
        }
        // Add button which update prices for all dealers
        private void ButtonExecuteAll_Click(object sender, EventArgs e)
        {
            var dealers = (BindingList<DealerBaseViewModel>)DgvDealers.DataSource;
            foreach (var dealer in dealers)
            {
                dealer.UpdatePrice();
                // Because we call `RaisePropertyChanged` in
                // setter of Price - prices will be automatically
                // updated in DataGridView
            }
        }       
    }
