    public ActionResult Index(string CouponCode)
        {
        	CouponCode= CouponCode.Trim();
        	var cart =(CartModel)System.Web.HttpContext.Current.Session["cart"];
      		if (string.IsNullOrWhiteSpace(CouponCode)) 
      		{
      		ModelState.AddModelError("", @"Your Error Message");//OR something you like.
    
      		}
    
        	if (ModelState.IsValid)
                {
               CouponModel model = new CouponModel();
            
            var coupon = model.GetList().FirstOrDefault(m => m.CouponCode == CouponCode);
            if (coupon != null)
            {
                cart.CouponApplied = true;
                cart.CouponId = coupon.CouponId;
                cart.CouponCode = coupon.CouponCode;
                cart.Price = cart.Price - cart.Price * 20 / 100;
                cart.Total = cart.Price * cart.Quantity;
                System.Web.HttpContext.Current.Session["cart"] = cart;              
    
                ViewBag.Message = "Coupon is applied Successfully";
            }
            else
            {
                ViewBag.Message = "Coupon not found or Expired!";
            }  
         
         }
           return View(cart);
        }
