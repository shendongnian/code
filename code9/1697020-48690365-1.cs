    public ReceiveOrderDialogWindow(OrdersViewModel viewModel)
    {
        InitializeComponent();
        this.DataContext = viewModel;
        this.SizeToContent = SizeToContent.WidthAndHeight;
    }
