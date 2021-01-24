     [HttpPost]
                public ActionResult AddDocument(ReservationDocumentsVM reservationDocumentsVM, HttpPostedFileBase postedFile)
                {
                    if (postedFile != null)
                    {
                        string path = Server.MapPath("~/Content/Documents/");
        
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        postedFile.SaveAs(path + Path.GetFileName(postedFile.FileName));
                        reservationDocumentsVM.VirtualPath = path + Path.GetFileName(postedFile.FileName);
        
                        reservationRepository.AddOrUpdateReservationDocuments(reservationDocumentsVM);
        
                      
                    }
                 
    
       return RedirectToAction("Index", "Reservation");
            }
