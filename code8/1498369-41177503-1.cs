    public DataTable getData(IList<string> Code, IList<string> category, IList<string> state, IList<string> Type, IList<string> general)
    
            {
                DataTable dt = new DataTable();
               
              
                  var result = _db.Sample.Where(x => (Code.Contains(x.Code) || Code==null) && (category.Contains(x.category)|| category==null) && (state.Contains(x.state)||state==null) && (general.Contains(x.general)||general==null))
    
    
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
