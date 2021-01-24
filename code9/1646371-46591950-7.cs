        public JsonResult GetStudentInfo(int studentId)
        {
            using (var db = new AppDbContext())
            {
                // Method syntax
                var student = db.Students
                    .SingleOrDefault(x => x.Id == studentId);
                // Query syntax
                //var student =
                //    from s in db.Students
                //    where s.Id == studentId
                //    select s;
                return Json(student, JsonRequestBehavior.AllowGet);
            }
        }
