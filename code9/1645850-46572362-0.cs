    public class Service1 : IService1
    {
        public void UpdateHoliday(List<Holiday> Holidays)
        {
            if(Holidays==null)
               throw new ArgumentNullException("Holidays");
            
            string cmdStr = String.Format("INSERT INTO HOLIDAY (HOLIDAY, Description)" +
                                       " VALUES('HOLIDAY','Description')");
    
            foreach (var item in Holidays)
            {
                (new DbHelper()).SqlExecute(cmdStr);
            }
        }
    
    
    } 
