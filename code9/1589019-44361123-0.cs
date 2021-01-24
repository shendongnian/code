    public ActionResult Excel_Data(HttpPostedFileBase excelfile)
            {
                if ( excelfile == null )
                {
                    ViewBag.Error = "Please select an excel file";
                    return View("Create");
                }else if (excelfile.FileName.EndsWith("xls") || excelfile.FileName.EndsWith("xlsx"))
                {
                    return View("Index");
                }
                else
                {
                   
            TempData["Error"] = "File type is incorrect";  //replaced tempdata with viewbag
                    return RedirectToAction("Create","AspNetAssessment_QuestionController")
                }
    
            }
