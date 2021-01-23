     [HttpGet]
        [Route("api/MemberApi/GetMembersWithLink/")]
        public object GetMembersWithLink()
        {
            var member = (from members in db.Members
                          where members.Status == 1
                          select new
                          {
                              members.MemberName,
                              members.Position,
                              members.Phone,
                              members.Picture,
                              members.MotherName,
                              members.Village,
                              members.Email,
                              linkName = (from gg in db.Members where gg.MemberID==  members.Link select gg.MemberName).FirstOrDefault()
                          }).ToList();
            return member.AsEnumerable();
        }
