    public JsonResult AddToCheckList(int id)
    {
        if(context.CheckList.Tasks.Exists(t => t.Id == id))
        {
            return Json(null); indicate error - show a hidden element containing a message
        }
        context.AddTaskToCheckList(id);
        return Json(true); // indicate success
    }
