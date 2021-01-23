    class Uc1
    {
    
        public Uc1() 
        {
            InitializeComponent();
            this.wireEvents();
        }
        // This will handle all controls events for well organized form sakes.
        private void wireEvents()
        {
            this.btnCompute.Click += OnBtnComputeEvent;
        }
        private void OnBtnComputeEvent(object sender, EventArgs e)
        {
            // i used int since i do not know exactly how to do this.
            int transpo = int.parseInt(this.txtTranspo.Text);
            int daily = int.parseInt(this.txtDaily.Text);
            double total = ((transpo + daily) / 100 * 100) // <--- this is just a random computation.
           
            this.btnTotal = string.format("{0:c}", total); // this will format the total to a currency.
        }
    
    }
