    public ActionResult Motors()
            {
                this.ViewBag.CatID = new SelectList(this.db1.motors, "id", "cat");
                return View();
            }
