    class IntHolder
    {
        public int id {get;set;}
    }
    public Products Editproducts([FromBody] IntHolder holder)
        {       
          //  Products Product = null;
            DBEntities bd = new DBEntities();
            Products SenMes = bd.Products.Find(holder.id);
            if (SenMes != null)
            {
                Products product = new Products
                {
                    Id = SenMes.Id,
                   Name_Product = SenMes.Name_Product,
                    Description = SenMes.Description,
                    Price = SenMes.Price,
                    MesAndProduct = SenMes.MesAndProduct
                };
              // Product = SenMes;
                return product;
            }
            return null;
        }
