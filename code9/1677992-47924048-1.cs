    public class CustomObject
    {
        public string Siteid {get; set; }
        public string Site {get; set; }
    }
    (...)
    select new CustomObject() { Siteid = st.Siteid, Site = st.FullName });
