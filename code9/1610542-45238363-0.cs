    public class TERMSTU
    {
      public DateTime? startdate { get; set; }
      public String Id { get; set; }
    }
     public class Graduation
        {
            public DateTime? ACAD_COMMENCEMENT_DATE { get; set; }
            public String Id { get; set; }
        }
    public class Report
    {
        private List<TERMSTU> TERMSSTUS;
        private List<Graduation> GRADUATIONS;
        public Report(ColleagueDataContext _DB)
        {
            var TERMSSTU = from t in _DB.TERMs
                           join stu in _DB.STUDENT_TERMS_VIEWs
                           on t.TERMS_ID equals stu.STTR_TERM
                           orderby t.TERM_START_DATE descending
                           select new { startdate = t.TERM_START_DATE, id = stu.STTR_STUDENT };
            TERMSSTUS = new List<TERMSTU>();
            foreach (var i in TERMSSTU)
            {
                TERMSSTUS.Add(new TERMSTU() { Id = i.id, startdate = i.startdate });
            }
            var graduation = from a in _DB.ACAD_CREDENTIALs
                             where a.ACAD_COMMENCEMENT_DATE != null
                             where a.ACAD_COMMENCEMENT_DATE < DateTime.Today
                             orderby a.ACAD_COMMENCEMENT_DATE descending
                             select a;
            GRADUATIONS = new List<Graduation>();
            foreach (var i in graduation)
            {
                GRADUATIONS.Add(new Graduation() { Id = i.ACAD_PERSON_ID, ACAD_COMMENCEMENT_DATE = i.ACAD_COMMENCEMENT_DATE });
            }
        }
        public List<TERMSTU> givestu()
        {
            return TERMSSTUS;
        }
        public List<Graduation> givegrad()
        {
            return GRADUATIONS;
        }
    }
