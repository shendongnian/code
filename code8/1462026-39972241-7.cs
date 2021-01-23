    [HttpGet]
    [Route("api/Members")]
    public List<MemberReturn> GetMembers()
    {
        var member = db.Members.Select(m=>
                new MemberReturn {
                    Name = m.FirstName + " " + m.LastName,
                    Title = m.Title,
                    ProjectId = m.ProjectId
                });
        return member.ToList();
    }
