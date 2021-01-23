    [HttpPost]
    public JsonResult Remove(Guid id)
    {    
        cartList.RemoveAll(p => p.ID.Equals(id));
    
        return Json(new { removed = true });
    }
