         public ActionResult FileSave(HttpPostedFileBase file)
                    {
            
                        string _FileName = null;
                        string _path = null;                   
                        _FileName = Path.GetFileName(file.FileName);
                        string ext = Path.GetExtension(_FileName);
                        string file1 = _FileName.Replace(" ", "");
            
                        if (ext.ToLower() == ".pdf" || ext.ToLower() == ".doc" || ext.ToLower() == ".jpg" || ext.ToLower() == ".docx" || ext.ToLower() == ".xls" || ext.ToLower() == ".xlsx" || ext.ToLower() == ".jpeg" || ext.ToLower() == ".png")
                        {
                          
                            string location = (System.Configuration.ConfigurationSettings.AppSettings["DocumentationLocation"]);
                            _path = Path.Combine(location, file1);
                            if (System.IO.File.Exists(_path))
                            {
                                System.IO.File.Delete(_path);
                                file.SaveAs(_path);
                            }
                            else
                            {
                                file.SaveAs(_path);
                            }
                        }
                        return View();
            
                    }
