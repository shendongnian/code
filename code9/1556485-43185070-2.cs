    List<TeamName> teamNameList = new List<TeamName>();
    teamNameList.Add(new TeamName() { TName = "T1",
        memberNameList = new List<MemberName> {
            new MemberName { MName = "M1" },
            new MemberName { MName = "M2" },
            new MemberName { MName = "M3" } } });
    teamNameList.Add(new TeamName() { TName = "T2",
        memberNameList = new List<MemberName> {
            new MemberName { MName = "M1" },
            new MemberName { MName = "M2" } } });
    teamNameList.Add(new TeamName() { TName = "T3",
        memberNameList = new List<MemberName> { new MemberName { MName = "M1" } } });
    List<List<MemberName>> combi = new List<List<MemberName>>();
    //indexes keep index of each member for each team
    List<int> indexes = new List<int>(teamNameList.Count);
    //initialize them to the first members
    for (int i = 0; i < teamNameList.Count; i++)
        indexes.Add(0);
    //We will enumerate all combinations in this loop
    while (true)
    {
        //Create a new entry for combi
        List<MemberName> members = new List<MemberName>();
        //Select respective member based on the current index value for each team
        for (int i = 0; i < teamNameList.Count; i++)
            members.Add(new MemberName() { MName = teamNameList[i].TName + teamNameList[i].memberNameList[indexes[i]].MName });
        combi.Add(members);
        //Increment indexes and go to the next combination
        for (int i = indexes.Count - 1; i >= 0; i--)
        {
            indexes[i]++;
            //If we enumerated all members of the current team - start from the beginning of that members
            //Else we should proceed with the next member
            if (indexes[i] == teamNameList[i].memberNameList.Count)
                indexes[i] = 0;
            else
                break;
        }
        //If we enumerated all combinations than all indexes will become zero because of the previous loop
        if (indexes.Sum() == 0)
            break;
    }
