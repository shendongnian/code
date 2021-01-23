    public JsonResult GetConsultationDescription(Int32 idService)
            {
                using(var entityDB = CreateConnection())
                {
                    var motifDescription = entityDB.SYS_vwService.Where(s => s.IDLang == cultureName && s.IdService == idService && s.IdCie == idCie).FirstOrDefault();
                    var base64 = Convert.ToBase64String(motifDescription.ServiceImage);
                    var imgSrc = String.Format("data:image/gif;base64,{0}", base64);
                    var imageDecode = imgSrc;
                    if (base64 == "AA==")
                    {
                        imageDecode = "";
                    }
                    var result = new { motifDescription, imageDecode };
    
    
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
            }
      }
