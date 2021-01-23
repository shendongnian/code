       [HttpGet]
            public ActionResult EditOrder(int? id)
            {
                _obj_order_detail = db.order_detail.Find(id);
                if (_obj_order_detail != null)
                {
                    _obj_order_detail.ProductCategories = db.category_detail.ToList(); //get category List
                    return View(_obj_order_detail);
                }
                else
                {
                    return view();
                }
    
            }
        
