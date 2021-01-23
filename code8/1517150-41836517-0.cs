     [HttpPost]
        public ActionResult UploadExcel(Probe probes, HttpPostedFileBase FileUpload)
        {
            var data = new List<string>();
            if (FileUpload != null)
            {  
                if (FileUpload.ContentType == "application/vnd.ms-excel" || FileUpload.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                {
                    var filename = FileUpload.FileName;
                    var targetpath = Server.MapPath("~/Doc/");
                    FileUpload.SaveAs(targetpath + filename);
                    var pathToExcelFile = targetpath + filename;
                    string FileName = Path.GetFileName(FileUpload.FileName);
                    string Extension = Path.GetExtension(FileUpload.FileName);
                    DataTable dataFound = Import_To_Grid(pathToExcelFile, Extension, "Yes");
                    List<ProbeData> dataProbList = new List<ProbeData>();
                    foreach (DataRow item in dataFound.Rows)
                    {
                        try
                        {
                            var probeName = item["Probe"].ToString();
                            var alreadyexist = db.Probes.Where(d => d.ProbeName == probeName).FirstOrDefault();
                            var probId = 0;
                            if (alreadyexist != null)
                            {
                                probId = alreadyexist.Probe_ID;
                            }
                            else
                            {
                                Probe objProb = new Probe();
                                objProb.ProbeName = probeName.ToString();
                                db.Probes.Add(objProb);
                                db.SaveChanges();
                                probId = objProb.Probe_ID;
                                ProbeData objPD = new ProbeData();
                                objPD.ProbeId = probId;
                                objPD.ProbeName = objProb.ProbeName;
                                dataProbList.Add(objPD);
                            }
                        }
                        catch (DbEntityValidationException ex)
                        {
                            foreach (var entityValidationErrors in ex.EntityValidationErrors)
                            {
                                foreach (var validationError in entityValidationErrors.ValidationErrors)
                                {
                                    Response.Write("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                                }
                            }
                        }
                        
                    }
                    //deleting excel file from folder  
                    if ((System.IO.File.Exists(pathToExcelFile)))
                    {
                        System.IO.File.Delete(pathToExcelFile);
                    }
                    ViewBag.ProbeData = dataProbList;
                    //ViewBag.SCImportData = dataSCImporobList;
                    return View("Index");
                }
                else
                {
                    //alert message for invalid file format  
                    data.Add("<ul>");
                    data.Add("<li>Only Excel file format is allowed</li>");
                    data.Add("</ul>");
                    data.ToArray();
                    return Json(data, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                data.Add("<ul>");
                if (FileUpload == null) data.Add("<li>Please choose Excel file</li>");
                data.Add("</ul>");
                data.ToArray();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }
        private DataTable Import_To_Grid(string FilePath, string Extension, string isHDR)
        {
            string conStr = "";
            switch (Extension)
            {
                case ".xls": //Excel 97-03
                    conStr = ConfigurationManager.ConnectionStrings["Excel03ConString"]
                             .ConnectionString;
                    break;
                case ".xlsx": //Excel 07
                    conStr = ConfigurationManager.ConnectionStrings["Excel07ConString"]
                              .ConnectionString;
                    break;
            }
            conStr = String.Format(conStr, FilePath, isHDR);
            OleDbConnection connExcel = new OleDbConnection(conStr);
            OleDbCommand cmdExcel = new OleDbCommand();
            OleDbDataAdapter oda = new OleDbDataAdapter();
            DataTable dt = new DataTable();
            cmdExcel.Connection = connExcel;
            //Get the name of First Sheet
            connExcel.Open();
            DataTable dtExcelSchema;
            dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
            connExcel.Close();
            //Read Data from First Sheet
            connExcel.Open();
            cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";
            oda.SelectCommand = cmdExcel;
            oda.Fill(dt);
            connExcel.Close();
            return dt;
            
        }
