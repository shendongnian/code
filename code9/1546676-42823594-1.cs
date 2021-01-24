     public ActionResult GetVATDetails(string id)
            {
                var vat = ExactService.SelectObjectByCode<VATCode>(id);
                vat.VATPercentages = ExactService.SelectObjects<VatPercentage>().Where(x => x.VATCodeID == vat.ID).ToList();
                return vat != null ? Json(vat, JsonRequestBehavior.AllowGet) : Json(false, JsonRequestBehavior.AllowGet);
            }
