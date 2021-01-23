    private void CheckData(long PKID, int ExpectedResult, string Server, IRepo repo)
    {
        var b = repo.GetAll();  
        b.Find(x => x.PKID == PKID).Result.ShouldBe(ExpectedResultId);
    }
