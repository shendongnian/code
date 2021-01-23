    //WebApi
    public List<ResourceDTO> GetWebAppLeaders()
        {
            List<ResourceDTO> webappLeaders = new List<ResourceDTO>();
            //Linq to get a list of employees that take part of WebApp
            var people = from x in _staffCtx.Resources
                         where (x.Active.HasValue && x.Active.Value && x.ManagerID.HasValue && x.FirstName.Length > 0)
                         select new ResourceDTO()
                         {
                             FirstName = x.FirstName,
                             LastName = x.LastName,
                             ResourceID = x.ResourceID,
                         };
            webappLeaders = people.ToList();
            foreach (var person in webappLeaders)
            {
                int personID = person.ResourceID;
                person.webappPupil = from u in _webappCtx.CompanyWebAppViews
                                     where (u.PupilID == personID)
                                     select new WebappDTO()
                                     {
                                         webappID = u.ID,
                                     };
                person.webappPupil.ToList();
                person.webappTeacher = from u in _webappCtx.CompanyWebAppViews
                                       where (u.TeacherID == personID)
                                       select new WebappDTO()
                                       {
                                           webappID = u.ID,
                                       };
                person.webappTeacher.ToList();
            }
            
            
            return webappLeaders.ToList();
        }
    //ResourceDTO
        public class ResourceDTO
    {
        public int ResourceID { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
        public string ExtensionNumber { get; set; }
        public string MobileNumber { get; set; }
        public string MobileSpeedDial { get; set; }
        public string IMAddress { get; set; }
        public int? ManagerID { get; set; }
        public string ManagerName { get; set; }
        public string DepartmentType { get; set; }
        //WebApp specific
        public IQueryable<WebAppDTO> webappPupil { get; set; }
        public IQueryable<WebAppDTO> webappTeacher { get; set; }
    }
    //WebAppDTO
    public class WebAppDTO
    {
        public int webappID { get; set; }
        public string pupilName { get; set; }
        public string teacherName { get; set; }
        public string webappDate { get; set; }
        public string pupilLearnt { get; set; }
        public string pupilComments { get; set; }
        public string teacherComments { get; set; }
        public List<WebAppDTO> WebApp { get; set; }
    }
