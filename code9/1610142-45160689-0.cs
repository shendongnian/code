    public ActionResult IsNameAvailble(string package_name,int id=0)
            {
                Dbfile db = new Dbfile ();
                var exist= db.GetAllList().FirstOrDefault(m => m.package_name == package_name);
                if (exist!= null)
                {
                    return Json(false, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
            }
