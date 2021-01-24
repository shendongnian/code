    public async Task<ActionResult> Edit(int id)
    {   
      // Only allow users to see "items" they have access to 
      // based on custom rules. If they enter a different ID,
      // prevent them from viewing/editing that information.
      string userId = User.Identity.GetUserId();
      var items = context.Items.Where(m => m.Userid == userId);
      return View(items);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(ItemVm itemVm){
      // Only allow users to edit their own "items".
      string userId = User.Identity.GetUserId();
      var item = context.Items.Where(m => m.Id == itemVm.ItemId && m.UserId == userId);
      if (item != null)
      {
        //update item stuff
      }
      return View();
    }
