            [HttpPost]
            public void SaveSalesInvoice(SalesModel model)
            {
                var myDataService = new DataService();
                myDataService.SaveSalesInvoice(model.Invoice);
    
            }
