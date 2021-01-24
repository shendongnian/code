    public ActionResult delete(int id)
    {
        var deleteActionObject = new DeleteAction();
        deleteActionObject.DeleteRecord(id);
        return RedirectToAction("Index");
    }
