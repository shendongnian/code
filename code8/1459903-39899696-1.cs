        private void CheckData(long PKID, int ExpectedResultId, string Server)
        {
            var repo = GetRepo(Server);
            repo.GetAll().Find(x => x.PKID == PKID).Result.ShouldBe(ExpectedResultId);
        }
