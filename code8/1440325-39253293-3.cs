    public class ProductIdAndQuantityListModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var request = controllerContext.HttpContext.Request;
            var products = new List<ProductIdAndQuantity>();
            for (int i = 0; i < 25; i++)
            {
                string productIdKey = string.Format("productid_{0}", i);
                string quantityKey = string.Format("productqty_{0}", i);
                string productIdVal = request[productIdKey];
                string quantityVal = request[quantityKey];
                if (productIdVal == null || quantityVal == null)
                    break;
                int productId = Convert.ToInt32(productIdVal);
                int quantity = Convert.ToInt32(quantityVal);
                var productIdAndQuantity = products.FirstOrDefault(x => productId == x.ProductId);
                if (productIdAndQuantity != null)
                {
                    productIdAndQuantity.Quantity += quantity;
                }
                else
                {
                    products.Add(new ProductIdAndQuantity()
                    {
                        ProductId = productId,
                        Quantity = quantity
                    });
                }
            }
            return products;
        }
    }
