            private void button1_Click_1(object sender, EventArgs e)
            {
    
    
                // Authenticate with PayPal
    var config = ConfigManager.Instance.GetProperties();
    var accessToken = new OAuthTokenCredential(config).GetAccessToken();
    var apiContext = new APIContext(accessToken);
    
    
    // Make an API call
    var payment = Payment.Create(apiContext, new Payment
    {
        intent = "sale",
        payer = new Payer
        {
            payment_method = "paypal"
        },
        transactions = new List<Transaction>
        {
            new Transaction
            {
                description = "Transaction description.",
                invoice_number = "001",
                amount = new Amount
                {
                    currency = "USD",
                    total = "100.00",
                    details = new Details
                    {
                        tax = "15",
                        shipping = "10",
                        subtotal = "75"
                    }
                },
                item_list = new ItemList
                {
                    items = new List<Item>
                    {
                        new Item
                        {
                            name = "Item Name",
                            currency = "USD",
                            price = "15",
                            quantity = "5",
                            sku = "sku"
                        }
                        
                    }
                }
            }
        },
        redirect_urls = new RedirectUrls
        {
            return_url = "http://x.com/return",
            cancel_url = "http://x.com/cancel"
        }
      
    });
                MessageBox.Show("API Request Sent to Paypal");     
    
            }
    
