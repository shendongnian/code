    public partial class CreateProduct : Window
    {
        private ObservableCollection<Liste> list = new ObservableCollection<Liste>();    
    
        public CreateProduct()
        {
            InitializeComponent();
            listBoxProduct.ItemsSource = list;
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
           float weight;
           int quantity;
           string customer, piece, material;
           customer = btnEditCustomer1.Text;
           piece = btnPiece.Text;
           material = txtMaterial.Text;
           quantity = Convert.ToInt32(txtQuantity.Text);
           weight = float.Parse(txtWeight.Text);
    
           if (customer != null && piece != null && material != null)
           {
              Liste kayit = new Liste();
    
              kayit.Customer = customer;
              kayit.Piece = piece;
              kayit.Material = material;
              kayit.Quantity = quantity;
              kayit.Weight = weight;
    
              list.Add(kayit);
           }
        }
    }
