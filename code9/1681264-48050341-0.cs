    [HttpPost]
        public JsonResult CaptureUserData(string IdentityNo, string FullName, 
        string Dob,string Gender, string PhoneNo, string PhoneNo1,                                            string Email, string Category, string Password                                          )
        {
            return Json(IdentityNo);
        }
