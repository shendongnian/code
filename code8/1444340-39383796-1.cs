    public List<SomeName> HRPersonnelContactInfoTelMethod(List<int> Recivers)
    {
       var HRPersonnelContactInfoTelService = App.Api.HRPersonnelContactInfoTelService.Instance().Data();
       var SMSGroupMemberService = App.Api.SMSGroupMemberService.Instance().Data();
       return (from x in SMSGroupMemberService
               where Recivers.Contains(x.GroupID)
               join v in HRPersonnelContactInfoTelService on x.Pers_Code equals v.Pers_Code
               select new { Pers_Code = (int)x.Pers_Code, Tel = v.Tel }).ToList();
    }
