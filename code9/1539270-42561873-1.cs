    public JsonResult LoadInsDet(int id)
        {
            var ins = from t in db.INSPECTIONDETAILS.Where(t=>t.InspectionID==id).ToList()
                      //where t.InspectionID == id 
                      select new InsDetDTO()
                      {
                          Id = t.ID,
                          AreaEquip = t.AreaEquipment,
                          Inspectionid = t.InspectionID
                      };
            return Json(ins, JsonRequestBehavior.AllowGet);
        }
