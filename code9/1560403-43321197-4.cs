    public SomeDTO {
        public bool IsMember {get;set}
        public List<Community> Communities {get;set;}
    }
    public ActionResult Index(string UserID, int CommunityID)
    {
        var hasMembership = IsMember(serID, CommunityID);
        var listOfCommunities = _repo.GetComunities();
        var dto = new SomeDTO
        {
            IsMember = hasMembership,
            Communities = listOfCommunities
        }
        return View(dto);
    }
    @if (Model.IsMember){
        // do or do not something
    }
