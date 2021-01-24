    using System;
    using System.Linq.Expressions;
    
    class Program
    {
        static void Main()
        {
            ShowMeTheLambda<Foo, Allocation>(s => new Allocation
            {
                Id = s.Id,
                UnitName = s.UnitName,
                Address = s.NewAddress,
                Tel = s.NewTel
            });
        }
        static void ShowMeTheLambda<TFrom, TTo>(Expression<Func<TFrom, TTo>> lambda)
        { }
    }
    class Foo
    {
        public int Id { get; set; }
        public string UnitName { get; set; }
        public string NewTel { get; set; }
        public string NewAddress { get; set; }
    }
    class Allocation
    {
        public int Id { get; set; }
        public string UnitName { get; set; }
        public string Tel { get; set; }
        public string Address { get; set; }
    }
