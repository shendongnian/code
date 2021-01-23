    public ActionResult AufgabenDetails(int id)
            {
                var p= new prjname { Title = "Album " + id };
                return View(p);
            }
