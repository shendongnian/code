    public ActionResult CatLittersDelete(int? Id)
        {
            CatLitter ni = db.CatLitters.Find(Id);
            if (Id != null)
            {
                foreach (var item in ni.Cats.Where(m => m.CatLitterId == Id).ToList())
                {
                    item.CatLitterId = null;
                    db.Entry(item).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            db.CatLitters.Remove(ni);
            db.SaveChanges();
            return RedirectToAction("CatPropCreate");
        }
