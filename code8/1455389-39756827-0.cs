        /// <summary>
        /// Get the correct view depending on the dropdown
        /// </summary>
        /// <param name="productType"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create(string productType)
        {
            Request request = new Request();
            switch (productType)
            {
                case "Accelerator":
                    request.RequestData = new AcceleratorRequestData();
                    request.ColloquialType = ColloquialType.Accelerator;
                    return View(request);
                case "BarrierAccelerator":
                    request.RequestData = new BarrierAcceleratorRequestData();
                    request.ColloquialType = ColloquialType.BarrierAccelerator;
                    return View(request);
                default:
                    return RedirectToAction("Index", "Requests");
            }
        }
