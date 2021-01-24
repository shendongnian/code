        public ActionResult Index(int? id)
        {
            if (! id.HasValue || id.Value < 1 )
            {
                return HttpNotFound();
            }
            
            List<String> studentList = new List<string>();
            var klasa = _db.Keuni.FirstOrDefault(x => x.klasaid == id.Value);
            if (studentList != null)
            {
               return View(klasa);
            }
            else
            {
                return HttpNotFound();
            }
        }
