    public ActionResult loaddata()
        {
            using (CMSEntities dc = new CMSEntities())
            {                
                var data = dc.ContentItems.select(m=>new{
    Name : m.Name,
    Title : m.Title,
    CreateDate : m.CreateDate,
    UpdateDate : m.UpdateDate,
    ItemContent : m.ItemContent,
    VisualOrder : m.VisualOrder
    }).toList()
                return Json(new { data = data }, JsonRequestBehavior.AllowGet);
            }
        }
