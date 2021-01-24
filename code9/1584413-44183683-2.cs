    public ApplicationDbContext Subgroup = new ApplicationDbContext();
    public ApplicationDbContext Group = new ApplicationDbContext();
    public ActionResult Index()
    {
        List<Group> Categories = Group.group.GroupJoin(Subgroup.subgroup, x => x.GroupId, y => y.GroupID, (Group, SubGroup) => new { Group, SubGroup }).Tolist();
        return View(Categories);
    }
