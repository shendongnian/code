    public async Task<ActionResult> Edit(Guid? id)
    {
         if (id == null)
         {
             return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
         }
         var slik_data_a01 = await db.slik_data_a01.FindAsync(id);
         if (slik_data_a01 == null)
         {
             return HttpNotFound();
         }
         //init Dropdown Data    
        ViewBag.jenissegmen = new SelectList((from x in db.master_segmenfasilitas
                                           select new { x.fasilitas, x.sandi }).ToList()
        //OrderByDescending to put the selected value on first row
        .OrderByDescending(o => o.sandi == slik_data_a01.kode_jenis_segmen)
        , "sandi", "fasilitas");
    
        
        //then return to the view.
         return View(slik_data_a01);
    }
