    if (userRegObj != null && userRegObj.imgfile != null && userRegObj.imgfile.FileName != null && userRegObj.imgfile.ContentLength > 1024000)//1 MB
                        {
                            TempData["msg"] = "danger~Profile Picture Should be Less Than 1 MB";
                            if (userRegObj.Id <= 0)
                            {
                                return View(userRegObj);
                            }
                            return RedirectToAction("Action", "Controller", new { id = userRegObj.Id });
                        }
    
    
    
                        else if (userRegObj != null && userRegObj.imgfile != null && userRegObj.imgfile.FileName != null)
                        {
                            string path = Path.Combine(Server.MapPath("~/Media/ProfilePics"), Path.GetFileName(userRegObj.imgfile.FileName)); // folder to save images
                            userRegObj.imagePath = Path.GetFileName(userRegObj.imgfile.FileName);
                            userRegObj.imgfile.SaveAs(path);
                        }
