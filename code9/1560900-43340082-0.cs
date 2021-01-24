     public ActionResult Index(HttpPostedFileBase file)
            {
                if (file != null && file.ContentLength > 0)
                    try
                    {
                        string path = Path.Combine(Server.MapPath("~/Files"),
                                                   Path.GetFileName(file.FileName));
                        file.SaveAs(path);
                        ViewBag.Message = "Success";
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Message = "Error:" + ex.Message.ToString();
                    }
                TempData["FileData"] = file;
                return RedirectToAction("NewControllerAction", "NewController");
            }
