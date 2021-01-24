            public JsonResult GetStudentListViewData([DataSourceRequest] DataSourceRequest request)
        {
            var studentData = db.sp_GetStudentData().Select(list => new StudentViewModel
            {
                FirstName = list.FirstName,
                Gender = list.Gender,
                DOB = list.DOB.Value.ToShortDateString(),
                Image = list.Image,
                CountryName = list.Name,
                ProvinceName = list.ProvinceName,
                Interset = list.Interset
            }).ToList();
            return Json(studentData.ToDataSourceResult(request));
        }
