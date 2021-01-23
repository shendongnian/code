    public ActionResult Test(int id)
        {
            int updateid = 1;
            var result = new
            {
                PhotoId = updateid
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }
