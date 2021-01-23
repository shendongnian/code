    interface IGenericClass<out TemplateClass> where TemplateClass : TestInterface {
        TemplateClass goo { get; }
    }
    class GenericClass<TemplateClass> : IGenericClass<TemplateClass> where TemplateClass : TestInterface
    {
        public TemplateClass goo { get; }
    }
