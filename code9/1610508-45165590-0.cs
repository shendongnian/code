    public JsonResult GetAssociatedProperty(int id)
            {
                try
                {
                    var property = _repository.GetLayerProperty(id);
    
                    return Json(new {
                        Result = "OK",
                        Id = property.Id,
                        VectorLayerId = property.VectorLayerId,
                        FieldName = property.FieldName,
                        FieldType = property.FieldType,
                        FieldValue = property.FieldValue,
                        Required = property.Required 
                    }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
    
                    throw;
                }
            }
