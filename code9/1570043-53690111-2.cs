            var result = from x in alldata
                         select new[]
                         {
                                Convert.ToString(x.pid),
                                Convert.ToString(x.pname),
                                Convert.ToString(x.pprice)
                         };
            return Json(new
            {
                aaData = result
            },
          JsonRequestBehavior.AllowGet);
        }
        public JsonResult deleteRecord(int ID)
        {
            try
            {
                var data = dbobj.products.Where(x => x.pid == ID).FirstOrDefault();
                dbobj.products.Remove(data);
                dbobj.SaveChanges();
                return Json(1, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(0, JsonRequestBehavior.AllowGet);
            }
        }
    }
