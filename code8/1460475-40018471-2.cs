    public class PobraniaSzukajModel
    {
        public IEnumerable<SelectListItem> UserTypes { get; set; }
    	public string psSelectedUserType { get; set; }
        public IEnumerable<SelectListItem> Columns { get; set; }
        public IEnumerable<string> psSelectedColumns { get; set; }
    	public string psText { get; set; }
    	public ResultsModel psResults { get; set; }
    }
