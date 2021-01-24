    // GET: Artigos/Edit/5
    public async Task<ActionResult> Edit(Guid? id)
    {
    	if (id == null)
    	{
    		return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    	}
    	Artigo artigo = await db.Artigoes.FindAsync(id);
    	if (artigo == null)
    	{
    		return HttpNotFound();
    	}
    	return View(artigo);
    }
