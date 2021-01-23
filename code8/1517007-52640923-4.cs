    [HttpPost]
    public JsonResult SaveEmployee(UserViewModel model)
    {
    string _fileName = "";
    if (Request.Files.Count > 0)
    {
    var _empid = int.Parse(Request.Form["Id"]);
    var _file = Request.Files[0];
    var _fName = Request.Files["file0"].FileName;
    var _dotIndex = _fName.LastIndexOf('.');
    var _ext = _fName.Substring(_dotIndex);
    var _configpath = RequestHelpers.GetConfigurationValue("ImageUpload");
    _fileName = _empid + "_IDPROOF" + _ext;
    var _dirPath = Server.MapPath(_configpath);
    var _filePath = Server.MapPath(_configpath) + _fileName;
    if (System.IO.Directory.Exists(_dirPath))
    {
    if (System.IO.File.Exists(_filePath))
    {
    System.IO.File.Delete(_filePath);
    }
    _file.SaveAs(_filePath);
    }
    else
    {
    System.IO.Directory.CreateDirectory(_dirPath);
    _file.SaveAs(_filePath);
    }
    }
    return Json(_IUser_Repository.GetUser(),JsonRequestBehavior.AllowGet);
    }
