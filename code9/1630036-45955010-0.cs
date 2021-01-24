    public class MyRequestModel
    {
        public DomainModelType Type { get; set; }
        public A ToDomainObject()
        {
            switch (Type)
            {
                case DomainModelType.A:
                    return new A();
                case DomainModelType.B:
                    return new B();
                case DomainModelType.C:
                    return new C();
                default:
                    throw new InvalidOperationException();
            }
        }
    }
    [Route("Stuff")]
    [HttpPost]
    public IHttpActionResult Stuff(MyRequestModel requestModel)
    {
        var myOriginalObject = requestModel.ToDomainObject();
        // do some type checking and perform logic
    }
