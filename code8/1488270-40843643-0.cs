    // GET: api/UserTraining1
        public IEnumerable<UserTraining> GetUserTrainings()
        {
            var userid = User.Identity.GetUserId();
            var usertrainings = db.Set<UserTraining>().Where(u => u.UserId == userid).Include(u=>u.Activities).ToArray();
            return usertrainings;
        }
