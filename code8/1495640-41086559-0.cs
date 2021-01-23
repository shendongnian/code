    public partial class BeerForm : Form
    {
        internal Consumer consumer ;
        public BeerForm(Consumer theconsumer)
        {
            InitializeComponent();
            consumer = theconsumer ;
           
        }
     
    // then use consumer variable in your BeerForm procedures. 
