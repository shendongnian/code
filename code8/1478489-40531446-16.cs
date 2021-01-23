    public class YourForm: Form
    {
        public YourForm()
        {
            InitializeComponent();
            var dealers = new List<DealerBase>
            {
                new Dealer1(),
                new Dealer2()
            };
            var bindSource = new BindingList<DealerBase>(dealers);
            dataGridView.DataSource = bindSource;
        }
        // Add button which update prices for all dealers
        private void ButtonUpdatePrices_Click(object sender, EventArgs e)
        {
            var dealers = (BindingList<DealerBase>)dataGridView.DataSource;
            foreach (var dealer in dealers)
            {
                dealer.UpdatePrice();
                // Because we call `RaisePropertyChanged` in
                // setter of Price - prices will be automatically
                // updated in DataGridView
            }
        }       
    }
