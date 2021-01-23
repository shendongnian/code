You cannot convert type JsonResult to List< T> :
  
        public JsonResult GetAllEmployees()
        {
            connection();
            con.Open();
            IList<EmpModel> EmpList = SqlMapper.Query<RootObject>(con, "GetEmpUsingDapper1").ToList();
            //con.Close();
            var data1 = EmpList.ToList();
            return Json(new { data = data1 }, JsonRequestBehavior.AllowGet);
        }
