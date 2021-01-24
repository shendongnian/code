    public class Rootobject
    {
        public Reporttemplate ReportTemplate { get; set; }
    }
    public class Reporttemplate
    {
        public Page[] Page { get; set; }
    }
    public class Page
    {
        public string Id { get; set; }
        public string LayoutId { get; set; }
        public Section[] Section { get; set; }
        public string text { get; set; }
    }
    public class Section
    {
        public string Id { get; set; }
        public string Body { get; set; }
        public object Content { get; set; }
    }
