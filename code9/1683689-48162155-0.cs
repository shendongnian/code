     public ActionResult GetFuranceOne()
        {
            FireViewModel _fireViewModel  = new FireViewModel();
            var query = (from w1 in db.V_PDCPowerDemandArchiveForMis
                         where db.V_LastEafHeat.Any(w2 => w1.DATE >= w2.StartTime)
                         orderby w1.DATE descending
                         select w1).Take(50);
            foreach (var item in query.ToList())
            {
                if (item.DATE.Minute % 5==0)
                {
                    _fireViewModel.Power.Add(item.EAF1);
                    _fireViewModel.Date.Add(item.DATE.ToShortTimeString());
                }
            }
            return PartialView("_Fire", _fireViewModel);
        }
