    var exampleTest = new Test();
    var example = new { exampleTest.myid, exampleTest.myid2 };
    var exampleType = example.GetType();
    var rci = exampleType.GetConstructors()[0];
    var parm = Expression.Parameter(typeof(Test), "p");
    var args = new[] { Expression.PropertyOrField(parm, "myid"), Expression.PropertyOrField(parm, "myid2") };
    var body = Expression.New(rci, args, exampleType.GetMembers().Where(m => m.MemberType == MemberTypes.Property));
    var lambda = Expression.Lambda(body, parm);
