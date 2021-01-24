    public List<Web_Group_joint_Profils> GetGroupAndId()
    {
        var grpId = context.WebGroupProfil
            .Select(a => new 
            {
                GroupName = a.GroupName,
                IDProfil = a.IDProfil
            })
            .AsEnumerable() // This forces EF to run the query and materialise the date as anon objects
            .Select(a=>new Web_Group_joint_Profils(a.GroupName, a.IDProfil)
            .ToList();
        return grpId;
    }
