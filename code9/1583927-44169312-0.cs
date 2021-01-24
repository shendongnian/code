    [HttpPost]
        public IActionResult AddOrder(OrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                var oOrder = new Order
                {
                    orderName = model.orderName,            
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    ....
                    ....
                    lkupType_1_ID = (model.SelectedTypeIDs.Length > 0) ? model.SelectedTypeIDs[0] : 0, // You can default it to null if it is Int?
                    lkupType_2_ID = (model.SelectedTypeIDs.Length > 1) ? model.SelectedTypeIDs[1] : 0,
                    lkupType_3_ID = (model.SelectedTypeIDs.Length > 2) ? model.SelectedTypeIDs[2] : 0,
                    ....
                };
        
                    _context.Add(oOrder);
            }
            return RedirectToAction(....);
        }
