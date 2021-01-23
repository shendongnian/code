    public ActionResult Delete(string name) {
        StorageModel.Init("Correct Container Name")
        StorageModel.deleteBlob(name);
        return View(refreshList());
    }
