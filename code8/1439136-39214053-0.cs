        // POST: LabData/ChemicalDelete/5
        [Authorize(Roles = "canDeleteDbAdmin")]
        [HttpPost, ActionName("ChemicalDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteChemicalConfirmed(int id)
        {
            foreach (SampleLocation l in db.SampleLocations)
            {
                if (l.ChemicalId == id)
                {
                    l.ChemicalId = null;
                    db.Entry(l).State = EntityState.Modified;
                }
            }
            db.SaveChanges();
            Chemical c = db.Chemicals.Find(id);
            db.Chemicals.Remove(c);
            db.SaveChanges();
            return RedirectToAction("ChemicalList");
        }
