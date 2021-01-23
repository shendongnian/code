            CustomerViewModel vm
            {
                get
                {
                    return (CustomerViewModel)DataContext;
                }
            }
          IGuest g
            {
                get
                {
                    return vm.CurrentGuest;
                }
            }
            public CartGuestControl()
            {
                this.InitializeComponent();
            }
