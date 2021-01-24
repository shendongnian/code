    [TestCase("Member1", Result = ...)]
    [TestCase("Member2", Result = ...)]
    public MyOutput MEMBER1(string memberName)
    {
        string member_name = memberName;
        string OU = "American Red Cross of Central";
        string status = "Yes";
        OperatingUnit.ChangeOU(Properties.driverGC, OU);
        MemberSearch.Search(Properties.driverGC, name, status);
        return Compare.statuses(Properties.driverGC);
    }
