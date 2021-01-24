    public async void PurchaseSelectedProduct(ProductModel product){
        if (product == null){
            MessageBox.Show("Product not valid", "PurchaseInApp Error");
            return;
        }
        // Init store context for purchase
        IInitializeWithWindow initWindow = (IInitializeWithWindow)(object)storeContext_;
    initWindow.Initialize(System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle);
        // Buy through in app purchase sdk
        StorePurchaseResult result = null;
        try { result = await product.StoreProduct.RequestPurchaseAsync(); }
    }
     
