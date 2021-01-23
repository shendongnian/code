    [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public JsonResult getAJAX()
        {
            using (TableEntities context = new TableEntities())
            {
                stock = (from c in context.stocks
                         select new stockAJAX
                         {
                             StockId = c.StockId,
                             ProductGroup = c.ProductGroup,
                             GroupType = c.GroupType,
                             ItemType = c.ItemType,
                             Model = c.Model,
                             SerialNo = c.SerialNo,
                             NR = c.NR,
                             Status = c.Status.ToString(),
                             Description = c.Description,
                             DateArrived = c.DateArrived.ToString(),
                             CurrentLocation = c.CurrentLocation,
                             TerminalId = c.TerminalId,
                         }
                                    ).Take(1000).ToList();
            }
            return Json(new
            {
                iTotalRecords = 1000,
                iTotalDisplayRecords = 10,
                sEcho = 10,
                aaData = stock}, JsonRequestBehavior.AllowGet);
        }
