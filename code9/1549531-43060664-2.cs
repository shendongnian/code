        public void UpdateRequest()
        {
            using (var trans = this.dbContext.Database.BeginTransaction())
            {
                this.actionComments = "Updating the request";
                this.TryFire(SwiftRequestTriggers.Update);
                SaveChanges();
                trans.Commit();
            }
        }
      protected void TryFire(SwiftRequestTriggers trigger)
        {
            if (!workflow.CanFire(trigger))
            {
                throw new Exception("Cannot fire " + trigger.ToString() + " from state- " + workflow.State);
            }
            workflow.Fire(trigger);
        }
