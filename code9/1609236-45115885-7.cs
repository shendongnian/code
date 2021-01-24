     public class SearchParameters{
            public string ssn_or_tin { get; set; }
            public SearchParameters()
            {
                this.ssn_or_tin = string.Empty;
            }
    
            internal List<SqlParameter> ToSqlParameterList()
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@ssn_or_tin", this.ssn_or_tin));
                return parameters;
            }
        }
    [HttpPost]
        public JsonResult GetAllCICO(SearchParameters searchParameters=null)
        {
            searchParameters = searchParameters ?? new SearchParameters();
            List<SqlParameter> parameters = searchParameters.ToSqlParameterList();
            var cicos = GetCICO(parameters).ToList();
            var jsonResult = Json(new { data = cicos }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
