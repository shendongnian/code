    public class Service : IService
    {
        public void DoStuff()
        {
            var detail = new MyResultClass
            {
                Code = 400,
                Description = "foo"
            };
            throw new WebFaultException<MyResultClass>(detail, HttpStatusCode.BadRequest);
        }
    }
