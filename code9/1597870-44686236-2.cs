        public IActionResult deletelname(pinfo pinfo)
        {
        
            var fsname = db.pinfo;
            var lsname = db.pinfo;
            var csomment = db.pinfo;
        
            foreach (var fname in fsname)
            {
                db.Remove(fname);
            }
        
            foreach (var lname in lsname){
                db.Remove(lname);
            }
        
            return View("Contact", db.pinfo.ToList());
        }
