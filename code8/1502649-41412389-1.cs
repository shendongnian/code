     // GET: AssetRequests/Create
            public ActionResult Create()
            {
    
                ViewBag.RequestStatusId = "New request";
                ViewBag.AssetRequestDate = DateTime.Now;
                ViewBag.AssetId = new SelectList(db.AssetTable, "Id", "AssetName");
                ViewBag.DistrictId = new SelectList(db.FacilitytTable, "Id", "DistrictName");
                ViewBag.RequestTypeId = new SelectList(db.RequestTypeTable, "Id", "RequestTypeName");
                return View();
            }
    [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<ActionResult> Create([Bind(Include = "Id,AssetRequestDate,FacilityId,AssetId,RequestTypeId, RequestStatusId")] AssetRequest assetRequest)
            {
                var currentUser = await manager.FindByIdAsync(User.Identity.GetUserId());
                
                if (ModelState.IsValid)
                {
                    assetRequest.User = currentUser;
                    assetRequest.AssetRequestDate = DateTime.Now;
                    assetRequest.RequestStatusId = 1;
                    db.AssetRequestTable.Add(assetRequest);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
