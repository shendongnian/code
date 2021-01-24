    public ActionResult GetEmployees()
            {
                using (TerasysDBEntities1 dc = new TerasysDBEntities1())
                {
                    dc.Configuration.LazyLoadingEnabled = false;
                    var clientes = dc.Clientes.OrderBy(a => a.Nombre).ToList();
                    return Json(new { data = clientes }, JsonRequestBehavior.AllowGet);
                }
            }
