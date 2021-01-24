        public JsonResult FetchTblData()
        {
            string MyTableName = Convert.ToString(Request.Form["TblName"]);
            DbContext result;
            
            try
            {
                Type tableType = typeof(CourseDesc);
                switch (MyTableName)
                {
                    case "CourseTbl":
                        tableType = typeof(CourseTbl);
                        break;
                    case "CourseDescTbl":
                        tableType = typeof(CourseDesc);
                        break;
                }
                using (EBContext db = new EBContext())
                {
                    result = db.Set(tableType);
                }
                return new JsonResult { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
             }
            catch (Exception ex)
            {
                string innerMessage = (ex.InnerException != null) ? ex.InnerException.Message : "";
                 return new JsonResult { Data = "Not Found", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }
