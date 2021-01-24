    public IQueryable<tbl_Person> ThirdMethod(bool isFirstPerson)
    {
        var ctx = new MyContextSQL();
        var temp = ctx.tbl_Person.Include("tbl_Student").Include("Department").Where(x =>
            (x.int_statID == 2 || x.int_statID == 1 || x.int_statID == 9) 
            && isfirstPerson ? 
                 (x.department != 90 && x.department != 94) : (x.department == 90 || x.department == 94)    
            && (x.workID == 789)
            && (x.clientID != 789247)
            && (x.auditID != 9)
            && (x.expDate >= new DateTime(2017, 1, 1))
            && (x.expDate <= DateTime.Today));
        var result = temp.OrderByDescending(x => x.expDate);
        return result;
    }
    public IQueryable<tbl_Person> PersonSelect1()
    {
        return this.ThirdMethod(true);
    }
    public IQueryable<tbl_Person> PersonSelect2()
    {
        return this.ThirdMethod(false);
    }
