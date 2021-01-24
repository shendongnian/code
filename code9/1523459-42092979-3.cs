    using System;
    using System.Web.Http.ModelBinding;
    [ModelBinder(typeof(FooModelBinder))]
    public class Foo
    {
        public DateTime time { get; set; }
    }
