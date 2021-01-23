    public DataTable getData(IList<string> Code, IList<string> category, IList<string> state, IList<string> Type, IList<string> general)
    
            {
                DataTable dt = new DataTable();
               
               if(Code!=null && category!=null && state !=null && type!=null && general!=null)
               {
                  var result = _db.Sample.Where(x => Code.Contains(x.Code) && [New conditions]); //----> Add your conditions by using &&
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
