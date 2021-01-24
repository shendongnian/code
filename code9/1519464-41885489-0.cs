    var vm = ( from p in db.Products
             join i in db.Images on p.ProductId equals i.Product_Id
             join s in db.Specifications on p.ProductId equals s.Product_Id
             select new ProductRegistrationViewModelVM
             {
                //Product
                p.Name,
                p.Produt_Code,
                p.Description,
                //Image
                i.Image_Description,
                i.Image_Name,
                i.image1,
                //Specifications
                s.Sz_Measurement_Unit,
                s.Size,
                s.Wg_Measurement_Unit,
                s.Weight,
                s.Price_Set,
                s.Price_Sold
             } );
    
    return View( vm.ToList() );
