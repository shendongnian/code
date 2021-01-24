    public string GenerateInvoiceDocument(Order order)
        {
            var customer = GetCustomer(order.CustomerNumber);
            var header = GenerateCustomerDocumentHeader(customer, DateTime.Now.AddYears(-1), order.Number, "", "", "", "", "", "", "", "", "", "", DateTime.Now.AddYears(-1), "", "", "", 1);
            var lines = new List<string>();
            for (var x = 0; x < order.InventoryCode.Count; x++)
            {
                var customerPrice = GetCustomerPrice(order.CustomerNumber, order.InventoryCode[x]);
                var newLine = GenerateDocumentLine(customerPrice.Price[x], (double)order.Quantity[x], customerPrice.Price[x], customerPrice.IncPrice[x], "0", customer.TaxCode.ToString(), "", "0", order.InventoryCode[x], order.InventoryDescription[x], "4", "001", "");
                lines.Add(newLine);
            }
            var result = _sdk.SetDataPath($"{_directory}{_company}");
            _sdk.OpenDocumentFiles();
            result = _sdk.DefineDocumentHeader(header, true);
            foreach (var line in lines)
            {
                result = _sdk.DefineDocumentLine(line);
            }
            result = _sdk.ImportDocument(3, 0);
            _sdk.CloseDocumentFiles();
            return result;
        }
