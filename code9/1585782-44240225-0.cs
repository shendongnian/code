     public ActionResult DropDownn(string query)
        {
            using (DynamicDBEntities db = new DynamicDBEntities())
            {
           var result = context.SP_DynamicCtrl(query);
                return result;
            }
        }
