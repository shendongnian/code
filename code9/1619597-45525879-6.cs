    public interface IDtoService {
        bool? MyReuseMethod(string ParameterId, bool istrueorfalse);
    }
    public class MyDtoServie : IDtoService {
        private MyDbContext dbContext;
        public MyDtoServie(MyDbContext dbContext) {
            this.dbContext = dbContext;
        }
        public bool? MyReuseMethod(string ParameterId, bool istrueorfalse) {
            var MyObject = dbContext.objeto.Where(c => c.myId == ParameterId);
            var MyDto = MyObject.FirstOrDefault();
            if(MDto == null) return null;
    
            if(!/*do some validations, if do not pass*/ ) {
                return false;
            }
    
            MyDto.Visible = istrueorfalse;            
            return dbContext.SaveChanges() > 0;
        }
    }
