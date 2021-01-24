    public interface ILoginLinkService
    {
        Dictionary<string, IList<NameValuePair>> GetLoginPageLinks();
    }
    public class LoginLinkService : ILoginLinkService
    {
        private readonly IUnitOfWork unitOfWork;
        public LoginLinkService(IUnitOfWork unitofwork)
        {
            this.unitOfWork = unitofwork;
        }
        public Dictionary<string, IList<NameValuePair>> GetLoginPageLinks()
        {
            var data = new Dictionary<string, IList<NameValuePair>>();
            var baseQuery = unitOfWork.Repository<LoginPageLink>().Queryable();
            var nonAnnouncementsQuery = baseQuery
                .Where(x => x.LoginPageLinkCategory.Code != LoginPageLinkCategory.AnnouncementsCode)
                .Select(x => new
                {
                    x.LoginPageLinkCategory.Code,
                    x.Name,
                    x.Url,
                    x.SortOrder
                });
            var announcementsQuery = baseQuery
                .Where(x => x.LoginPageLinkCategory.Code == LoginPageLinkCategory.AnnouncementsCode &&
                    (DbFunctions.DiffDays(x.CreatedDate, DateTimeOffset.Now) ?? 0) <= 7)
                .Select(x => new
                {
                    x.LoginPageLinkCategory.Code,
                    x.Name,
                    x.Url,
                    x.SortOrder
                });
            var fullQuery = nonAnnouncementsQuery.Union(announcementsQuery)
                .OrderBy(x => new { x.Code, x.SortOrder })
                .Select(x => new
                {
                    x.Code,
                    x.Name,
                    x.Url
                });
            fullQuery.Each(x =>
            {
                var pair = new NameValuePair() { Name = x.Name, Value = x.Url, };
                IList<NameValuePair> list;
                if (data.ContainsKey(x.Code))
                {
                    list = data[x.Code];
                }
                else
                {
                    list = new List<NameValuePair>();
                    data[x.Code] = list;
                }
                list.Add(pair);
            });
            return data;
        }
    }
}
