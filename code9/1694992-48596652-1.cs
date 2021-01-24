    public ActionResult Download(int id)
            {
                Item item = db.Items.Find(id);
    
                if (item != null)
                {
                    item.DownloadCount++;
                    db.SaveChanges();
    
                    string fileLocation = string.Format(
                        "{0}/{1}",
                        Request.Url.GetLeftPart(UriPartial.Authority),
                        item.Location.Replace(@":\\", "/").Replace(@"\", "/")
                    );
    
                    return Json(new { success = true, fileLocation = fileLocation},
                        JsonRequestBehavior.AllowGet);
                }
    
                return Json(new { success = false, responseText = "Bad request." },
                    JsonRequestBehavior.AllowGet);
            }
