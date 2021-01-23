     class Program
    {
        static void Main(string[] args)
        {
            List<Request> lstRequest = new List<Request>();
            lstRequest.Add(new Request(1, 1));
            lstRequest.Add(new Request(2, 2));
            List<DemoView> lstDemoView = new List<DemoView>();
            lstDemoView.Add(new DemoView(1, "Ram", "Finance"));
            lstDemoView.Add(new DemoView(1, "Sam", "Manager"));
            lstDemoView.Add(new DemoView(1, "Dan", "Admin"));
            lstDemoView.Add(new DemoView(2, "abc", "Finance"));
            var query = (from demo in lstDemoView
                          group demo by demo.ApproverType
                          into grp             
                         select new
                         {
                             RequestID = grp.RequestID,
                             SurrogateID = request.SurrogateID,
                             Finance =  lstDemoView.Any(x => x.SurrogateID == request.SurrogateID && x.ApproverType.ToLower() == "finance") ? lstDemoView.SingleOrDefault(x => x.SurrogateID == request.SurrogateID && x.ApproverType.ToLower() == "finance").ApproverName:"",
                             Manager = lstDemoView.Any(x => x.SurrogateID == request.SurrogateID && x.ApproverType.ToLower() == "manager") ? lstDemoView.SingleOrDefault(x => x.SurrogateID == request.SurrogateID && x.ApproverType.ToLower() == "manager").ApproverName : "", 
                             Admin =  lstDemoView.Any(x => x.SurrogateID == request.SurrogateID && x.ApproverType.ToLower() == "admin") ? lstDemoView.SingleOrDefault(x => x.SurrogateID == request.SurrogateID && x.ApproverType.ToLower() == "admin").ApproverName:""
                         }).ToList();
        }
    }
    public class Request
    {
        public int RequestID { get; set; }
        public int SurrogateID { get; set; }
        public Request(int RequestID, int SurrogateID)
        {
            this.RequestID = RequestID;
            this.SurrogateID = SurrogateID;
        }
    }
    public class DemoView
    {
        public int SurrogateID { get; set; }
        public string ApproverName { get; set; }
        public string ApproverType { get; set; }
        public DemoView(int SurrogateID, string ApproverName, string ApproverType)
        {
            this.SurrogateID = SurrogateID;
            this.ApproverName = ApproverName;
            this.ApproverType = ApproverType;
        }
    }
