    public class MyService
    {
        public void MyMethod(var model)
        {
            var myModel = Mapper.Map<LogoDto, R_Logo>(model);  
        }
    }
