    public ActionResult Add()
        {
            var model = new SampleViewModel
            {
                PayeSelectListItems = _db.paye.Select(p=>new SelectListItem {Text =p.PayeName ,Value = PayeID.tostring() }).toList(),
                //ReshteSelectListItems = ...
                
            };
            return View(model);
        }
