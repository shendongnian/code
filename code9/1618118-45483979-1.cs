    public ActionResult ElementType_Read([DataSourceRequest]DataSourceRequest request)
    {
        List<ElementType> elementTypeList = db.ElementType.ToList();
        IQueryable<ElementType> elementTypes = elementTypeList.AsQueryable();
    
    
        DataSourceResult result = elementTypes.ToDataSourceResult(request, elementType => new ElementTypeDTO
        {
            ElementTypeId = elementType.ElementTypeId,
            TypeName = elementType.TypeName.Current,
        });
    
        return Json(result);
    }
    
    [AcceptVerbs(HttpVerbs.Post)]
    public ActionResult ElementType_Destroy([DataSourceRequest]DataSourceRequest request, ElementTypeDTO elementType)
    {
        if (ModelState.IsValid)
        {
            var currentElementType = db.ElementType.Find(elementType.ElementTypeId);
            db.ElementType.Attach(currentElementType);
            db.ElementType.Remove(currentElementType);
            db.SaveChanges();
        }
    
        return Json(new[] { elementType }.ToDataSourceResult(request, ModelState));
    }
