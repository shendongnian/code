            if (ModelState.IsValid)
            {
                List<FileDetail> fileDetails = new List<FileDetail>();
                
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    HttpPostedFileBase httpPostedFileBase = Request.Files[i];
                    if (httpPostedFileBase != null)
                    {
                        Stream stream = httpPostedFileBase.InputStream;
                        BinaryReader bReader = new BinaryReader(stream);
                        byte[] bytes = bReader.ReadBytes((Int32)stream.Length);
                    }
                    HttpPostedFileBase postedFileBase = Request.Files[i];
                    if (postedFileBase != null)
                    {
                        var fileName = Path.GetFileName(postedFileBase.FileName);
                        FileDetail fileDetail = new FileDetail()
                        {
                            FileName = fileName,
                            Extension = Path.GetExtension(fileName),
                            Id = Guid.NewGuid()
                        };
                        fileDetails.Add(fileDetail);
                        //Save the Byte Array as File.
                        var path = Path.Combine(Server.MapPath("~/App_Data/Upload/"),
                            fileDetail.Id + fileDetail.Extension);
                        postedFileBase.SaveAs(path);
                        postedFileBase.InputStream.Flush();
                    }
                }
                invoice.FileDetails = fileDetails;
                db.Invoices.Add(invoice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(invoice);
        }
