    class ClassA
    {
        public int MyProperty { get; set; }
        public int MyProperty2 { get; set; }
    }    
    class Foo<T>
    {
        public Foo(Expression<Func<T, Object>> selector)
        {
            var props = ((NewExpression)selector.Body).Members.Select(p => p.Name).ToList();
        }
    }
    Foo<ClassA> foo = new Foo<ClassA>(u => new { u.MyProperty, u.MyProperty2 });
