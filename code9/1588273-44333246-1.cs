    public ActionResult ProductOutputList()
        {
            var request = System.Web.HttpContext.Current.Request;
            var settings = Properties.Settings.Default;
            using (var db = new Database(settings.DbType, settings.DbConnection))
            {
                var response = new Editor(db, "productoutputs", "ProductOutputId")
                    .Model<ProductOutputDatatablesModel>()
                    .Field(new Field("productoutputs.ProductId")
                        .Options("products", "ProductId", "Name")
                    )
                    .LeftJoin("products", "products.ProductId", "=", "productoutputs.ProductId")
                    .Field(new Field("productoutputs.DesignId")
                        .Options("designs", "DesignId", "Name")
                    )
                    .Process(request)
                    .Data();
                return Json(response, JsonRequestBehavior.AllowGet);
            }
        }
