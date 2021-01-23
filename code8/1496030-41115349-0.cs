    [HttpPost]
    public ActionResult Excel(FormCollection formCollection)
    {
        if (Session["myID"] == null)
        {
            return ExpireSession();
        }
        if (Request.Form.AllKeys.Contains("ConfirmCustomOrder"))
        {
            return ConfirmExcelDocument();
        }
        var model = new ExcelModel
        {
            CustomOrderList = null,
            PurchaseOrderList = null,
            TriggerOnLoad = false,
            TriggerOnLoadMessage = string.Empty
        };
        if (!ModelState.IsValid)
            return View(model);
        var file = Request?.Files["UploadedFile"];
        if (file == null || (file.ContentLength <= 0) || string.IsNullOrEmpty(file.FileName))
            return View(model);
        using (var package = new ExcelPackage(file.InputStream))
        {
            var currentSheet = package.Workbook.Worksheets;
            var workSheet = currentSheet.First();
            
            switch (workSheet.Cells[1, 1].Value.ToString().Trim())
            {
                case "Custom Order":
                    // Custom order
                    IterateCustomOrder(model, workSheet);
                    Session["CustomOrderList"] = model.CustomOrderList;
                    break;
                case "Purchase Order":
                    // Purchase order
                    IteratePurchaseOrder(model, workSheet);
                    Session["PurchaseOrderList"] = model.PurchaseOrderList;
                    break;
                default:
                    model.TriggerOnLoadMessage = "Incorrect file format, please use our template.";
                    model.TriggerOnLoad = true;
                    model.CustomOrderList = null;
                    model.PurchaseOrderList = null;
                    return View(model);
            }
        }
        return View(model);     
    }
    [HttpPost]
    public ActionResult ConfirmExcelDocument()
    {
        var model = new ExcelModel
        {
            TriggerOnLoad = true,
            TriggerOnLoadMessage = string.Empty,
            PurchaseOrderList = null,
            CustomOrderList = null
        };
        if (Session["CustomOrderList"] == null)
            return View(model);
        var list = (IEnumerable<CustomOrderRow>)Session["CustomOrderList"];
        Session["CustomOrderList"] = null;
        // ... Do some validating etc. 
        return View(model);
    }
