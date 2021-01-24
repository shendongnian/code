    public interface IRepository
    {
       IEnumerable<myCustomModel1> FetchDataForcustomModel1(int key);
    }
    public class Repository : IRepository
    {
       private my_dbEntities db = new my_dbEntities(); //Created with Entity Framework - needed to fill my model with database data
       public IEnumerable<myCustomModel1> FetchDataForcustomModel1(int key);
       {                   
            IEnumerable<myCustomModel1> myModelData= (from d in db.table1                           
                                  where d.idD == key                                 
                                  select new myCustomModel1
                                  {
                                     idL = d.idL,
                                     idP = d.idP,
                                     Name = d.Name
                                     CustomModel2= (from l in db.table2
                                              where l.fkidD == d.idD                                           
                                              select new myCustomModel2
                                              {
                                                  idData = l.fkidD                                             
                                              }).ToList()
                                  }).ToList();
            return myModelData;
      }
    }
