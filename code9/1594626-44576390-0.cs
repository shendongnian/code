        public ActionResult deliveredItems(bool deliveredItem = false)
        {
            var machineChecklist = from m in db.machineChecklist
                                   select m;
            if (deliveredItem == true)
            {
                machineChecklist = machineChecklist.Where(p => p.itemDelivered);
            }
            else
            {
                return View(machineChecklist.ToList());
            }
            return View(machineChecklist.OrderBy(x => x.machineID));
         }
