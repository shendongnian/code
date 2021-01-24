    public class MyDtoServie : IDtoService  
        public bool? MyReuseMethod(bool istrueorfalse) {
            var MyObject = _dbContext.objeto.Where(c => c.myId == ParameterId);
            var MyDto = MyObject.FirstOrDefault();
            if(MDto == null) return null;
    
            if(!/*do some validations, if do not pass*/ ) {
                return false;
            }
    
            MyDto.Visible = istrueorfalse;
            _dbContext.SaveChanges();
            return true;
        }
    }
