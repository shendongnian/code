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
        List<int> indexes = new List<int>(teamNameList.Count);
        for (int i = 0; i < teamNameList.Count; i++)
            indexes.Add(0);
        while (true)
        {
            List<MemberName> members = new List<MemberName>();
            for (int i = 0; i < teamNameList.Count; i++)
                members.Add(new MemberName() { MName = teamNameList[i].TName + teamNameList[i].memberNameList[indexes[i]].MName });
            combi.Add(members);
            for (int i = indexes.Count - 1; i >= 0; i--)
            {
                indexes[i]++;
                if (indexes[i] == teamNameList[i].memberNameList.Count)
                    indexes[i] = 0;
                else
                    break;
            }
            if (indexes.Sum() == 0)
                break;
        }
