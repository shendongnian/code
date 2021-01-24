    private List<Product> _selectedProducts;
    
            public List<Product> SelectedProducts
            {
                get
                {
                    return _selectedProducts;
                }
            }
    
            public string ProductName { get; set; }
    
            public string ProductCategory { get; set; }
    
            private void frmSearchProducts_Load(object sender, EventArgs e)
            {
                _selectedProducts = new List<Product>();
                
                this.KeyPreview = true;
    
                //TODO: do search product            
            }
    
            protected override void OnKeyDown(KeyEventArgs e)
            {
                base.OnKeyDown(e);
    
                switch (e.KeyCode)
                {
                    case Keys.Enter:
                        {
                            //TODO: Get your selected on gridview...
                            _selectedProducts = new List<Product>();
    
                            // set dialog result
                            DialogResult = DialogResult.OK;
    
                            // close form
                            Hide();
                        }
                        break;
                    
                }
            }
