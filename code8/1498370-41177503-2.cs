    public DataTable getData(IList<string> Code, IList<string> category, IList<string> state, IList<string> Type, IList<string> general)
    
            {
                DataTable dt = new DataTable();
               
                  if(code==null)
                  code=''
                  if(category==null)
                  category=''
                  if(state==null)
                  state=''
                  if(general==null)
                  general=''               
                  var result = _db.Sample.Where(x => (Code.Contains(x.Code) || Code=='') && (category.Contains(x.category)|| category=='') && (state.Contains(x.state)||state=='') && (general.Contains(x.general)||general==''))
    
    
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
