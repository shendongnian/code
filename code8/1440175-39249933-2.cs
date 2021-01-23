    public JsonResult AjaxGetJsonData()
        {
            Database db = new Database();
            var userList = db.YourTable.Select(m => new
            {
                m.Name,
                m.Position,
                m.Office
            });
            return Json(new
            {
                data = userList
            }, JsonRequestBehavior.AllowGet);
        }
