     public void AnswerGrid_DeleteItem(int id)
        {
            using (NubeSSPRContext db = new NubeSSPRContext())
            {
                var policy = db.AnswerPolicies.Find(id);
                db.Entry(policy).State = EntityState.Deleted;
                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    ModelState.AddModelError("",
                         String.Format("Item with id {0} no longer exists in the database.", id));
                }
            }
        }
        // The id parameter name should match the DataKeyNames value set on the control
        public void GeneralGrid_UpdateItem(int id)
        {
            Response.Redirect("~/Admin/GeneralSettings?GeneralPolicyID=" + id.ToString(), false);
        }
