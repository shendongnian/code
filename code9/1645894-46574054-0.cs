    public ActionResult GetCIPDesc(int CIP_ID)
        {
            CIP_Number temp = new CIP_Number();
            List<CIP_Number> desc = db.CIP_Numbers.Where(x => x.CIP_ID == CIP_ID).ToList();
            ViewBag.CIPNumDesc = new SelectList(desc, "CIP_ID", "Description");
            return PartialView("CIPDescPartial");
        }
