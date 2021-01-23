     public DataTable getData(IList<string> Code, IList<string> category, IList<string> state, IList<string> Type, IList<string> general)
        {
            DataTable dt = new DataTable();
            var result = null;
            if(category != null && state != null && type != null && general != null)
            {
            result = _db.Sample.Where(x => Code.Contains(x.Code) && category.Contains(x.category) && state.Contains(x.state) && general.Contains(x.general));
            //if you wish to check for any one
            //result = _db.Sample.Where(x => Code.Contains(x.Code) || category.Contains(x.category) || state.Contains(x.state) || general.Contains(x.general));
            }
            if (result == null)
            {
                return null;
            }
            else
            {
                dt = Utility.ToDataTable(result.ToList());
            }
            return dt;
        }
