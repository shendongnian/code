        public ActionResult Index()
        {
            try
            {
                 //Code logic here
            }
            catch (HttpException ex)
            {
                if (ex.ErrorCode == 500)
                    return RedirectToAction("error", "error");
            }
            return View();
        }
