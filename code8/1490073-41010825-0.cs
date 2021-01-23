    using FluentValidation;
    namespace FluentDemo
    {
        class Program
        {
            static void Main(string[] args) 
            {
                // TODO
            }
        }
        class A
        {
            public string MyProperty { get; set; }
        }
        class B
        {
            public string OtherProperty { get; set; }
            public A A { get; set; }
        }
        class C
        {
            public string DifferentProperty { get; set; }
            public B B { get; set; }
        }
        class AValidator : AbstractValidator<A>
        {
            public AValidator()
            {
                RuleFor(a => a.MyProperty)
                    .NotNull(); 
            }
        }
        class BValidator : AbstractValidator<B>
        {
            public BValidator(IValidator<A> aValidator)
            {
                RuleFor(b => b.OtherProperty)
                    .NotNull();
    
                RuleFor(b => b.A)
                    .SetValidator(aValidator);
            }
        }
        class CValidator : AbstractValidator<C>
        {
            public CValidator(IValidator<B> bValidator)
            {
                RuleFor(c => c.DifferentProperty)
                    .NotNull();
    
                RuleFor(c => c.B)
                    .SetValidator(bValidator);
            }
        }
    }
