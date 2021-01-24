    public JsonResult CheckStudentNameAlreadyExists(string studentName)
    {
        bool isNameAvailable = /* method checking your DB */
        return Json(isNameAvailable , JsonRequestBehavior.AllowGet);
    }
