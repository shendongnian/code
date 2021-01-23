        [HttpGet]
        public ActionResult Index(string bedRoomType = "", double amountPaid = 0)
        {
            var viewModel = new TenantIndexVm();
            using (var context = new RentEntities())
            {                
                viewModel.Payments = context.Payment.Where(x => (x.Rent.BedRoomType == bedRoomType || bedRoomType == "") && (x.AmountPaid >= amountPaid)).Include("Rent.Tenant");
            }
            return View(viewModel);
        }
