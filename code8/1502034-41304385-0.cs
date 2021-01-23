    [HttpPost]
    public void Like(int ID)
    {
        Contribution C = new Contribution(ID);
        C.likePost();
        RedirectToAction("ActionName")
    }
