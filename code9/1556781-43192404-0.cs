    @{
        var pointShop = Model.Order.OrderLines[0];
        string supplier == null;
    
        if (pointShop.SupplierId = 27942) {
        supplier = "If any question, please contact us";
        }
        else if (pointShop.SupplierId = 6543) {
        supplier == "Please call us";
        }
        else if (pointShop.SupplierId = 8723) {
        supplier == "You are welcome to write us";
        }
    }
